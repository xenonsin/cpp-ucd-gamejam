using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance;

    private bool win;
    private bool inGame;

    public Dictionary<string, int> playerList = new Dictionary<string, int>();
    public Dictionary<string, Text> scoreList = new Dictionary<string, Text>(); 
    public Text P1Text;
    public Text P2Text;
    public Text P3Text;
    public Text P4Text;

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        Instance = null;
    }

	// Use this for initialization
	void Awake () {
	    if (Instance == null)
	    {
	        Instance = this;
	        playerList.Add("p1", 0);
	        playerList.Add("p2", 0);
	        playerList.Add("p3", 0);
	        playerList.Add("p4", 0);
	        scoreList.Add("p1", P1Text);
	        scoreList.Add("p2", P2Text);
	        scoreList.Add("p3", P3Text);
	        scoreList.Add("p4", P4Text);

	    }
	    else
	    {
	        Destroy(gameObject);
	    }
	    DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (win)
	        Win();

	    if (!inGame)
	    {
	        if (Input.GetButtonDown("Ready"))
	        {
	            Application.LoadLevel(Random.Range(1, 4));
                //Application.LoadLevel(1);
	        }

            DisplayBoardScore();
	    }

	}

    public void SetInGame()
    {
        inGame = true;
    }

    public void IncrementScore(string pl)
    {
        if (playerList.ContainsKey(pl))
        {
            playerList[pl]++;
        }

        CheckWin();
    }

    public void SetText(string pl, int n)
    {
        if (scoreList.ContainsKey(pl))
        {
            scoreList[pl].text = n.ToString();
        }
    }

    public int GetScore(string pl)
    {
        if (playerList.ContainsKey(pl))
        {
            return playerList[pl];
        }
        return 0;
        
    }

    public void CheckWin()
    {
        foreach (var entry in playerList)
        {
            if (entry.Value == 2)
                win = true;
        }
    }

    public void DisplayBoardScore()
    {
        foreach (var entry in scoreList)
        {
            entry.Value.text = playerList[entry.Key].ToString();
        }
    }

    void Win()
    {
        
    }
}
