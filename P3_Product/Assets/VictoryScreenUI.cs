using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Makes us able to use the scenemanager
using UnityEngine.SceneManagement;

// This is the methods for the victoryScreenUI which is the screen popping up after the game is won
public class VictoryScreenUI : MonoBehaviour {

    public string loadMenu = "MainMenu";

    // PlayAgain uses the scenemanager with the built-in function Loadscene to load the game's scene by doing it this way it basically restarts the scene
    // and makes it so that the player stats are reset again since they are loaded in the Start method the first time
    // it uses the GetActiveScene method to get the scene of the game. This is the most efficient way to do it.
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // The menu function is supposed to load the menu scene but for now it just write a comment in the console window.
    public void Menu()
    {
        SceneManager.LoadScene(loadMenu);
    }
}
