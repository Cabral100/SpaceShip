using UnityEngine;

public class player : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public float speed = 10.0f;
    public float boundY = 4f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var vel = rb2d.linearVelocity;

        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        vel.x = 0;
        rb2d.linearVelocity = vel;

        var pos = transform.position;

        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }

        transform.position = pos;
    }

//    public void TomarTiro()
//    {
//        GameManager gm = FindObjectOfType<GameManager>();
//        gm.PerderVida();
//    }
}