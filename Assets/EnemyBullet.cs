using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player>();
    }
    void Update()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            player.vidas--;
        }
        if (coll.gameObject.CompareTag("meteor"))
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}