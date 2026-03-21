using UnityEngine;

public class Shot : MonoBehaviour
{
    public float boundX = 9f;

    void Update()
    {
        if (transform.position.x > boundX)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "meteor")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "enemy")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
            
            // busca o player e adiciona o score
            GameObject.FindWithTag("Player").GetComponent<player>().score += 5;
        }
        if (coll.gameObject.tag == "enemyBullet")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}