using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 0.3f;

    SpriteRenderer spriteRenderer;
    float nextFireTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        float direction = transform.localScale.x < 0 ? -1f : 1f;

        Vector3 spawnOffset = new Vector3(direction * 0.5f, 0.2f, 0f);
        GameObject arrow = Instantiate(arrowPrefab, transform.position + spawnOffset, Quaternion.identity);

        AudioManager.Instance?.PlayShoot();
        arrow.GetComponent<Arrow>().SetDirection(direction);

        GetComponent<Animator>()?.SetTrigger("shoot");
    }

}