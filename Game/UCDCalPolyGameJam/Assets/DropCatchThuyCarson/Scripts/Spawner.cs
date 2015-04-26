using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject redCandy;
    public GameObject blueCandy;
    public GameObject yellowCandy;
    public GameObject greenCandy;
    public float delay = 2f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateCandy", 1f, delay);
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void CreateCandy()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                Instantiate(redCandy);
                break;
            case 2:
                Instantiate(blueCandy);
                break;
            case 3:
                Instantiate(greenCandy);
                break;
            case 4:
                Instantiate(yellowCandy);
                break;
        }
    }
}
