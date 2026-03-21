using UnityEngine;

public class player : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public KeyCode shot = KeyCode.Space;
    public float speed = 10.0f;
    public float boundY = 4f;
    public int score = 0;
    private Rigidbody2D rb2d;
    public int vidas = 3;

    public GameObject tiroPrefab;
    public float shotCooldown = 0.5f;
    private float nextShotTime = 0f; 
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

        if (vidas <= 0)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(shot) && Time.time > nextShotTime)
        {
            nextShotTime = Time.time + shotCooldown;  // NOVO
            GameObject tiro = Instantiate(tiroPrefab,transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
            tiro.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(10f, 0f);
        }
    }

//    public void TomarTiro()
//    {
//        GameManager gm = FindObjectOfType<GameManager>();
//        gm.PerderVida();
//    }
}