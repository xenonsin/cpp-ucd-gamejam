using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public bool test = false;
    public GameObject[] playercounts;
	void Update ()
    {
        playercounts = GameObject.FindGameObjectsWithTag("Player");
        if (playercounts.Length == 1)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            PlayerMovement pc;
            pc = go.GetComponent<PlayerMovement>();
            GameManager.Instance.EndRoundWithWinner(pc.player);
        }
        else if (playercounts.Length == 0)
        {
            GameManager.Instance.LoadBoardLevel();
        }
	}
}
