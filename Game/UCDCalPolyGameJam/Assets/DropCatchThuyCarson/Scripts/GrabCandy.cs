using UnityEngine;
using System.Collections;

public class GrabCandy : MonoBehaviour {

    private Rigidbody2D rb;
    public float range = 16.0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        float random = Random.value;
        //Debug.Log("Cos 0: " + Mathf.Cos(0));
        //Debug.Log( random + " : " + Mathf.Cos(random * Mathf.PI));
        transform.position = new Vector3(transform.position.x - range * random, transform.position.y - ( 1 - Mathf.Sin(random*Mathf.PI)) * 3);
        rb.velocity = new Vector2(0, 5);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
