using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinnerScene : MonoBehaviour {

    public GameObject first;
    public GameObject second;
    public GameObject third;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public Dictionary<string, GameObject> objectList = new Dictionary<string, GameObject>();

    private bool ready;

	// Use this for initialization
	void Start () {

        objectList.Add("p1", p1);
        objectList.Add("p2", p2);
        objectList.Add("p3", p3);
        objectList.Add("p4", p4);

        ready = false;

	
	}
	
	// Update is called once per frame
	void Update ()
	{

	    if (Input.GetButtonDown("Ready"))
	    {
	        GameManager.Instance.RestartGame();
	    }

	    if (ready) return;

        var playerList = GameManager.Instance.playerList;

        foreach (var entry in playerList)
        {
            switch (entry.Value)
            {
                case 0:
                    objectList[entry.Key].transform.position = new Vector3(third.transform.position.x, third.transform.position.y, 0f);
                    break;
                case 1:
                    objectList[entry.Key].transform.position = new Vector3(second.transform.position.x, second.transform.position.y, 0f);
                    break;
                case 2:
                    objectList[entry.Key].transform.position = new Vector3(first.transform.position.x, first.transform.position.y, 0f);
                    break;
            }
        }

        ready = true;
	}
}
