using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}