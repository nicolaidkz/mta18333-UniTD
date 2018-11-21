using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this displayes the lives in the text canvas on the screen
public class LivesUI : MonoBehaviour {

    // this is the text variable where the text canvas is passed to in the inspector
    public Text livesText;
	
	// Update is called once per frame
	void Update () {
        // here we set the text in the canvas to be the lives variable from the playstats class out of "/" ofLives from playerstats
        livesText.text = PlayerStats.lives.ToString() + "/" + PlayerStats.ofLives.ToString() + " HP";
	}
}
