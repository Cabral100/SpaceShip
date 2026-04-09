using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float boundY = 4f;

    public GameObject bulletPrefab;
    public float shootRate = 2f;
    private player playerObj;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerObj = GameObject.FindWithTag("Player").GetComponent<player>();
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
        if(playerObj.score > 0 && playerObj.score % 25 == 0)
        {
            StartCoroutine(SlowDown());
        }
    }

    void Shoot()
    {
        Vector2 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position + (Vector3)(dir * 0.5f), Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().linearVelocity = dir * 6f;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            playerObj.vidas--;
            Destroy(gameObject);
        }
    }

    private IEnumerator SlowDown()
    {
        float speedOriginal = speed;
        speed = 2f;
        yield return new WaitForSeconds(10f);
        speed = 3f;
    }
}