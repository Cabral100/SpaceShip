using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 4f;
    public float boundY = 4f;
    private player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player>();
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            player.vidas--;
        }
    }
}