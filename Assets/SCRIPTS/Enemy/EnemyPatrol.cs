using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Transform leftEdge;
    [SerializeField] Transform rightEdge;

    [Header("Ground/Wall Detection")]
    [SerializeField] Transform groundDetect;
    [SerializeField] float detectRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    [Header("Additional settings")]
    [SerializeField] bool isInvincible = false;
    [SerializeField] int health = 1;
    [SerializeField] bool isFlying = false;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    bool movingRight = true;
    bool isAlive = true;

    float turnCooldown = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update() { }

    void FixedUpdate()
    {
        if (!isAlive) return;

        if (turnCooldown > 0f)
            turnCooldown -= Time.fixedDeltaTime;
        bool isRunning = true;
        animator.SetBool("isRunning", isRunning);

        CheckEdges();
        Patrol();
    }

    void Patrol()
    {
        float direction = movingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
        spriteRenderer.flipX = !movingRight;

    }

    void CheckEdges()
    {
        if (turnCooldown > 0f) return;

        if (movingRight && transform.position.x >= rightEdge.position.x)
        {
            TurnAround();
            return;
        }

        if (!movingRight && transform.position.x <= leftEdge.position.x)
        {
            TurnAround();
            return;
        }

        if (!isFlying)
        {
            bool groundAhead = Physics2D.OverlapCircle(groundDetect.position, detectRadius, groundLayer);
            if (!groundAhead)
            {
                TurnAround();
            }
        }

    }
    void TurnAround()
    {
        movingRight = !movingRight;
        turnCooldown = 0.1f;

        // Flip ground detect position
        Vector3 pos = groundDetect.localPosition;
        pos.x *= -1;
        groundDetect.localPosition = pos;
    }

    // ─── Death ───────────────────────────────────────────────────────────
    public void Die()
    {
        if (isInvincible) return;
        if (health > 1)
        {
            health--;
            return;
        }
        isAlive = false;
        bool dead = true;
        bool isRunning = false;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("die", dead);
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
        GetComponent<Collider2D>().enabled = false;
        
        Destroy(gameObject, 0.8f);
    }

    //Debugging : visualize ground detection radius
    void OnDrawGizmosSelected()
    {
        if (groundDetect == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundDetect.position, detectRadius);
    }
}