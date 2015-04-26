using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);

	public Vector2 direction = new Vector2(10, 10);

	private Vector2 movement;
	// Use this for initialization
	private Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		movement = new Vector2(speed.x * direction.x,
		                    speed.y * direction.y);
	}

	void fixedUpdate()
	{
		rb.velocity = movement;
	}
}
