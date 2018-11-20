using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static int ofLives;
    public static int lives;
    public int startLives = 100;

    public static int ofWaves;
    public static int waves;
    public static int waveCounter;
    public int startWaves;

    public static bool victoryDeterminator = false;

    public int currency;
    public Text currencyText;
    public int Currency
    {
        get
        {
            return currency;
        }
        set
        {
            currency = value;
            currencyText.GetComponent<Text>().text = currency + " $";
        }
    }

    // Use this for initialization
    void Start () {
        lives = startLives;
        ofLives = startLives;

        waves = startWaves;
        ofWaves = startWaves;
        waveCounter = 1;

        currency = Currency;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
