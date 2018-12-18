using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // this lets us pass the main scene in the inspector
    public string levelToLoad = "Main";

    // this lets us pass both scenefaders one for screen one and one for screen two
    public SceneFader sceneFaderOne;
    public SceneFader sceneFaderTwo;

    // uses the scenefader to load the level that was passed into the variable before from the inspector
    public void Play()
    {
        sceneFaderOne.FadeTo(levelToLoad);
        sceneFaderTwo.FadeTo(levelToLoad);
    }
	
    // throws a message in the console since we have no describtion yet
	public void Description()
    {
        Debug.Log("Go to description!");
    }
}
