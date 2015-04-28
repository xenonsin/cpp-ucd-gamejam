using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

    public float speed = 10f;
    public float jump = 300f;
    public string player;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool onFloor = true;
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("PrintScore", 1f, 2f);
    }

    private void Move(float h, float v)
    {
        Vector3 movement = new Vector3(h, rb.velocity.y, 0f);

        movement.x = movement.x * speed * Time.deltaTime;
        rb.velocity = movement;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw(player + " Horizontal");
        //float v = Input.GetAxisRaw(player + " Vertical");

        Move(h, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 50)
        {
            //Application.LoadLevel("gameover");
            GameManager.Instance.EndRoundWithWinner(player);
        }

        if (Input.GetButtonDown(player + " Action"))
        {
            Jump();
        }

        PrintScore();
    }

    void Jump()
    {
        if (onFloor)
        {
            rb.AddForce(Vector2.up * jump);
            onFloor = false;
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (onFloor)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, coll.transform.position.z + 5);
            }
        }

        if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "Player")
        {
            onFloor = true;
        }
        else if (coll.gameObject.tag == "redCandy" ||
            coll.gameObject.tag == "blueCandy" ||
            coll.gameObject.tag == "greenCandy" ||
            coll.gameObject.tag == "yellowCandy")
        {
            if (coll.gameObject.tag == "redCandy" && player == "P1" ||
                coll.gameObject.tag == "blueCandy" && player == "P2" ||
                coll.gameObject.tag == "greenCandy" && player == "P3" ||
                coll.gameObject.tag == "yellowCandy" && player == "P4")
            {
                score += 5;
            }
            else
            {
                score += 1;
            }
        }
    }

    void PrintScore()
    {
        //Debug.Log(player +" Score: " + score);
        GameManager.Instance.SetText(player,score);
    }
}
