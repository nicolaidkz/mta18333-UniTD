using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int ofLives;
    public static int lives;
    public int startLives = 100;

    public static int ofWaves;
    public static int waves;
    public static int waveCounter;
    public int startWaves;

    public static int currency;
    public int startCurrency = 100;

    public static bool victoryDeterminator = false;

	// Use this for initialization
	void Start () {
        lives = startLives;
        ofLives = startLives;

        waves = startWaves;
        ofWaves = startWaves;
        waveCounter = 1;

        currency = startCurrency;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
