using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "Main";

    public SceneFader sceneFaderOne;
    public SceneFader sceneFaderTwo;

    public void Play()
    {
        sceneFaderOne.FadeTo(levelToLoad);
        sceneFaderTwo.FadeTo(levelToLoad);
    }
	
	public void Description()
    {
        Debug.Log("Go to description!");
    }
}
