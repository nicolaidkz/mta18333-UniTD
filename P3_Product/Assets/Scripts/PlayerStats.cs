using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this class controls everything that has to do with the players stats such as lives number of waves and the currency.
public class PlayerStats : MonoBehaviour
{

    // this is the variables that controls the players lives/ofLives and the starting lives
    public static int ofLives;
    public static int lives;
    public int startLives = 100;

    // this is the variables that controls the waves/ofWaves and the number of waves from the start. The waveCounter make sure the waves increase in the display 
    public static int ofWaves;
    public static int waves;
    public static int waveCounter;
    public int startWaves;

    public static bool victoryDeterminator = false;

    // variables that control currency
    public int currency1;
    public int currency2;
    public Text currencyTextP1;
    public Text currencyTextP2;

    public int Currency
    {
        get
        {
            return currency1; // get currency
        }
        set
        {
            currency1 = value;

            currencyTextP1.GetComponent<Text>().text = currency1 + " $"; // getcomponent currencyText and set string to currency $
        }
    }

    public int Currency2
    {
        get
        {
            return currency2; // get currency
        }
        set
        {
            currency2 = value;
            
            currencyTextP2.GetComponent<Text>().text = "$ " + currency2; // getcomponent currencyText and set string to currency $
        }
    }

    // Use this for initialization
    void Start()
    {
        lives = startLives;
        // same for ofLives
        ofLives = startLives;

        // same here as with lives
        waves = startWaves;
        ofWaves = startWaves;
        // waveCounter is set to 1 to show that the game starts at wave 1
        waveCounter = 1;

        // sets currency equal to the values passed in the inspector and changes the text in the text ui elements
        currency1 = Currency;
        currency2 = Currency2;
        currencyTextP1.GetComponent<Text>().text = currency1 + " $";
        currencyTextP2.GetComponent<Text>().text = "$ " + currency2;
    }
}