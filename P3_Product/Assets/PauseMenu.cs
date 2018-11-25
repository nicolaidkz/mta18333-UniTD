using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject ui;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public string loadMenu = "MainMenu";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
	}

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

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
