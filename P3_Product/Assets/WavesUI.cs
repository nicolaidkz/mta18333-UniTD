using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour {

    public Text wavesText;

    void Update () {
        for (int i = 1; i <= PlayerStats.ofWaves; i++)
        {
            wavesText.text = ((PlayerStats.waves - PlayerStats.waves) + PlayerStats.waveCounter).ToString() + "/" + PlayerStats.ofWaves.ToString() + " Waves";
        }
    }
}
