using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float maxLifetime = 3f;
    [SerializeField] int damage = 1;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        //Destroy(gameObject, maxLifetime);
    }

    public void SetDirection(float dir)
    {
        rb.linearVelocity = new Vector2(dir * speed, 0f);
        sr.flipX = dir < 0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //EnemyPatrol enemy = other.GetComponent<EnemyPatrol>();
        EnemyPatrol enemy = other.GetComponentInParent<EnemyPatrol>();
        if (enemy != null)
        {
            enemy.Die();
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("groundLayer"))
        {
            Destroy(gameObject);
        }
    }
}