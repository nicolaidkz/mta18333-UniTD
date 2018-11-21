using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script determines everything that happens when we lose a game, end a game, restart a game, pause a game, etc.
public class GameManager : MonoBehaviour {

    // This boolean just let the program know when the game is over
    public static bool gameIsOver;

    // This is the variable where the game over and victory screen canvas are passed to
    public GameObject gameOverUI;
    public GameObject victoryScreenUI;
    public GameObject instrctionTextUI;
    public GameObject sharedStatsUI;
    public GameObject P1StatsUI;
    public GameObject P2StatsUI;

    // the start method is run once when the script is run, it sets the gameIsOver variable to be false from the start
    void Start()
    {
        gameIsOver = false;
    }
	
	// Update is called once per frame
	void Update () {
        // if the game is over it simply returns since we don't need to run update anymore
        if (gameIsOver)
            return;

        // here it calls the gameOver method once the players base reach 0 or less lives
		if (PlayerStats.lives <= 0)
        {
            GameOver();
        }

        // here it calls the victory method if the player has more than 0 lives and the victoryDeterminator variable from the playerStats class is true
        if (PlayerStats.lives > 0 && PlayerStats.victoryDeterminator == true){
            Victory();
        }
	}

    void GameOver()
    {
        gameIsOver = true;

        // this sets the gameOverUI canvas to be visible and write a log in the console window that the game was lost.
        instrctionTextUI.SetActive(false);
        sharedStatsUI.SetActive(false);
        P1StatsUI.SetActive(false);
        P2StatsUI.SetActive(false);
        gameOverUI.SetActive(true);
        
        Debug.Log("Game over!");
    }

    void Victory()
    {
        gameIsOver = true;

        // this sets the victoryUI canvas to be visible and write a log in the console window that the game was won
        instrctionTextUI.SetActive(false);
        sharedStatsUI.SetActive(false);
        P1StatsUI.SetActive(false);
        P2StatsUI.SetActive(false);
        victoryScreenUI.SetActive(true);
        
        Debug.Log("Victory!");
    }
}
