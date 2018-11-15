using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script determines everything that happens when we lose a game, end a game, restart a game, pause a game, etc.
public class GameManager : MonoBehaviour {

    public static bool gameIsOver;

    public GameObject gameOverUI;
    public GameObject victoryScreenUI;

    void Start()
    {
        gameIsOver = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameIsOver)
            return;

		if (PlayerStats.lives <= 0)
        {
            GameOver();
        }

        if (PlayerStats.lives > 0 && PlayerStats.victoryDeterminator == true){
            Victory();
        }
	}

    void GameOver()
    {
        gameIsOver = true;

        gameOverUI.SetActive(true);
        Debug.Log("Game over!");
        // end screen here this will have play again and menu.
        // if play again this has to reset lives, waves and victory boolean in the Playerstats class
    }

    void Victory()
    {
        gameIsOver = true;

        victoryScreenUI.SetActive(true);
        Debug.Log("Victory!");
        // end screen that says victory and perhaps display score and shows play again and menu buttons
        // if play again this has to reset lives, waves and victory boolean in the Playerstats class
    }
}
