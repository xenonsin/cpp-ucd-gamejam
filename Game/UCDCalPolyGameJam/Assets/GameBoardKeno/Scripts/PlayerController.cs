using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    // This should be either p1, p2, p3, p4
    public string player;

    public float speed = 3f;

    public bool horizontalMovement;
    public bool verticalMovement;

	// Use this for initialization
	void Start ()
	{

	    rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw(player + " Horizontal");
        float v = Input.GetAxisRaw(player + " Vertical");

        Move(h, v);
    }

    void Update()
    {
        if (Input.GetButtonDown(player + " Action"))
        {
            Jump();
        }
    }

    private void Move(float h, float v)
    {
        
       Vector3 movement = new Vector3(h,v,0f);
       movement = movement.normalized * speed * Time.deltaTime;
       rb.MovePosition(transform.position + movement);
            
        
    }

    void Jump()
    {
        Debug.Log(player + " pressed action button!");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "finish")
        {
            GameManager.Instance.EndRoundWithWinner(player);
        }
    }
}
