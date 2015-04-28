using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameBoard : MonoBehaviour
{

    public GameObject squareStart;
    public GameObject squareOne;
    public GameObject squareEnd;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public Dictionary<string, GameObject> objectList = new Dictionary<string, GameObject>();

    private bool ready;

	// Use this for initialization
	void Awake ()
	{
        objectList.Add("p1", p1);
        objectList.Add("p2", p2);
        objectList.Add("p3", p3);
        objectList.Add("p4", p4);

	    ready = false;


	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (ready) return;
	    if (GameManager.Instance == null)
	    {
	        Debug.LogError("No instance of game manager!");
	        return;
	    }
        var playerList = GameManager.Instance.playerList;

        foreach (var entry in playerList)
        {
            switch (entry.Value)
            {
                case 0:
                    objectList[entry.Key].transform.position = new Vector3(squareStart.transform.position.x, squareStart.transform.position.y, 0f);
                    break;
                case 1:
                    objectList[entry.Key].transform.position = new Vector3(squareOne.transform.position.x, squareOne.transform.position.y, 0f);
                    break;
                case 2:
                    objectList[entry.Key].transform.position = new Vector3(squareEnd.transform.position.x, squareEnd.transform.position.y, 0f);
                    break;
            }
        }

	    ready = true;
	}
}
