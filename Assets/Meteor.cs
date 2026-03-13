using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 4f;
    public float boundY = 4f;

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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("shot"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}