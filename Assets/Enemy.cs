using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float boundY = 4f;

    public GameObject bulletPrefab;
    public float shootRate = 2f;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("Shoot", 1f, shootRate);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        var pos = transform.position;

        if (pos.y > boundY) pos.y = boundY;
        if (pos.y < -boundY) pos.y = -boundY;

        transform.position = pos;

        if (pos.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Vector2 dir = (player.position - transform.position).normalized;

        bullet.GetComponent<Rigidbody2D>().linearVelocity = dir * 6f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("shot"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}