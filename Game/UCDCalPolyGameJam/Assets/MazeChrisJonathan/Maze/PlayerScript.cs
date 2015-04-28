using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(5, 5);
	private Vector2 movement;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		movement = new Vector2 (
			speed.x * inputX,
			speed.y * inputY);
	}

	void FixedUpdate(){
		rb.velocity = movement;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "finish")
        {
          
        }
    }


}
