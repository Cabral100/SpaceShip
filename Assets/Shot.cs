using UnityEngine;

public class Shot : MonoBehaviour
{
    public KeyCode shot = KeyCode.Space;
    public float speed = 10f;
    public float boundX = 9f;

    private Rigidbody2D rb2d;
    public GameObject player;

    bool isShot = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D (Collision2D coll){
    if (coll.gameObject.tag == "meteor"){
        Destroy(coll.gameObject);
        isShot = false;
    }
    if (coll.gameObject.tag == "enemy"){
        Destroy(coll.gameObject);
        isShot = false;
    }



    }

    void Update()
    {
        var posPlayer = player.transform.position;

        if (!isShot)
        {
            transform.position = new Vector2(posPlayer.x + 1f, posPlayer.y);
        }

        // atirar
        if (Input.GetKeyDown(shot) && !isShot)
        {
            rb2d.linearVelocity = new Vector2(speed, 0f); 
            isShot = true;
        }

        var pos = transform.position;

        if (pos.x > boundX)
        {
            ResetShot();
        }
    }

    void ResetShot()
    {
        isShot = false;
        rb2d.linearVelocity = Vector2.zero;
    }
}