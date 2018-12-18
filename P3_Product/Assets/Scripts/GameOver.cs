using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Makes us able to use the scenemanager
using UnityEngine.SceneManagement;

// This is the methods for the gameOverUI which is the screen popping up after the game is lost
public class GameOver : MonoBehaviour {

    // makes us able to put the mainMenu scene into the inspector
    public string loadMenu = "MainMenu";

    // adds the scenefader to the inspector
    public SceneFader sceneFader;

    // Retry uses the scenemanager with the built-in function Loadscene to load the game's scene by doing it this way it basically restarts the scene
    // and makes it so that the player stats are reset again since they are loaded in the Start method the first time
    // it uses the GetActiveScene method to get the scene of the game. This is the most efficient way to do it.
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    // it uses the scenefader to load the menu
    public void Menu() {
        sceneFader.FadeTo(loadMenu);
    }
}
