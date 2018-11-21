using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class controls everything that has to do with the players stats such as lives number of waves and the currency.
public class PlayerStats : MonoBehaviour {

    // this is the variables that controls the players lives/ofLives and the starting lives
    public static int ofLives;
    public static int lives;
    public int startLives = 100;

    // this is the variables that controls the waves/ofWaves and the number of waves from the start. The waveCounter make sure the waves increase in the display 
    public static int ofWaves;
    public static int waves;
    public static int waveCounter;
    public int startWaves;

    public static int currency;
    public int startCurrency = 100;

    // this variable determines whether the game is won or lost
    public static bool victoryDeterminator = false;

	// Use this for initialization
	void Start () {
        // by initializing our playerStats variables here we make sure that everytime the scene is reset the variables reset which is nice for replayability
        // lives is set equal to startlives which is passed to the script in the inspector
        lives = startLives;
        // same for ofLives
        ofLives = startLives;

        // same here as with lives
        waves = startWaves;
        ofWaves = startWaves;
        // waveCounter is set to 1 to show that the game starts at wave 1
        waveCounter = 1;

        currency = startCurrency;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
