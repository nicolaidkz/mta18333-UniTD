using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // lets us pass a ui element via the inspector
    public GameObject ui;

    // lets us pass a scene in this case the main menu to the inspector
    public string menuSceneName = "MainMenu";

    // lets us pass a scenefader via the inspector
    public SceneFader sceneFader;

    // lets us pass a scene yet again
    public string loadMenu = "MainMenu";
	
	// Update is called once per frame
    // listens for a key input in this case escape to pause the game which just toggle's the overlay on and off
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
	}

    // toggle the pause overlay on and off and sets the timescale to 0 to make the game pause and when clicked again sets it to 1 to make the game run at normal speed
    public void Toggle()
    {
        // This sets the gameobject to false which is going to disable it
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            // pauses the game by setting the frame update time to 0
            Time.timeScale = 0f;
        }
        else
        {
            // sets the frame update time back to 1
            Time.timeScale = 1f;
        }
    }

    // uses the scenefader to load the active scene which is the game itself
    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    // uses the scenefader to load the main menu scene
    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
