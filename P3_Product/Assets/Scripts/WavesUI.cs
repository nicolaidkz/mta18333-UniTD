using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this displayes the waves in the text canvas on the screen
public class WavesUI : MonoBehaviour {

    // this is the text variable where the text canvas is passed to in the inspector
    public Text wavesText;

    void Update () {
        for (int i = 1; i <= PlayerStats.ofWaves; i++)
        {
            // this takes the wave we are currently at and write that out of how many total waves we have for each wave in the loop
            wavesText.text = ((PlayerStats.waves - PlayerStats.waves) + PlayerStats.waveCounter).ToString() + "/" + PlayerStats.ofWaves.ToString();
        }
    }
}
