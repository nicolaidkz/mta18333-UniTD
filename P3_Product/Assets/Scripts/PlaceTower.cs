using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
// Instantiate copies of the objects and store it so we can manipulate it during the game.
    private PlayerStats GameMaster;
    private WaveSpawner Wave;
    public GameObject towerPrefab;
    public GameObject towerPrefab2;
    public GameObject P2towerPrefab;
    public GameObject P2towerPrefab2;
    private GameObject tower;
    public GameObject posMaster;
    // Integers to store costs for the two towers.
    public int cost;
    public int cost2;
    public string towerPosition;

// Check if monster variable is null on node and if we have the required cost and if place is true.
    private bool CanPlaceTower()
    {
        return tower == null;
    }

// Method run when pressing mouse button down.
    void OnMouseDown()

// Check if place is true so you can not spawn while wave is going
    { if (Wave.place == true) {
// Place Player 1 tower 1 and deduct cost
        if (Input.GetMouseButton(1) && CanPlaceTower() && GameMaster.Currency >= cost2 && Input.GetKey("a") == false)
        {
            tower = (GameObject) Instantiate(towerPrefab2, transform.position, Quaternion.identity);
            GameMaster.Currency -= cost2;
        }

// Place Player 1 tower 2 and deduct cost.
        if (CanPlaceTower() && Input.GetMouseButton(1) == false && GameMaster.Currency >= cost && Input.GetKey("a") == false)
        {
                tower = (GameObject) Instantiate(towerPrefab, transform.position, Quaternion.identity);
                GameMaster.Currency -= cost;
        }
// Place Player 2 tower 1 and deduct cost
            if (Input.GetMouseButton(1) && CanPlaceTower() && GameMaster.Currency2 >= cost2 && Input.GetKey("a"))
        {
            tower = (GameObject)Instantiate(P2towerPrefab2, transform.position, Quaternion.identity);
            GameMaster.Currency2 -= cost2;
        }

// Place Player 2 tower 2 and deduct cost
            if (CanPlaceTower() && Input.GetMouseButton(1) == false && GameMaster.Currency2 >= cost && Input.GetKey("a"))
        {
            tower = (GameObject)Instantiate(P2towerPrefab, transform.position, Quaternion.identity);
            GameMaster.Currency2 -= cost;
        }
    }
}

// Access component of GameMaster object, PlayerStats.
    void Start ()
    {
        GameMaster = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
        Wave = GameObject.Find("GameMaster").GetComponent<WaveSpawner>();
        posMaster = GameObject.Find("PositionMaster");
    }

    // here we actually go into clientscript and call "GetPosition"
    // which should hopefully run CV and return a string containing the x,y of a tower
    // we then split that string into integers and parse those to MatchPosition, which in
    // turn matches those coordinates to a field on the gameboard, and returns another string
    // in the form of a letter and a number, e.g. "A1" for the very first field.
    // we can use this string to place a tower on the correct field! 
    string GetPosition()
    {
        var cScript = posMaster.GetComponent<ClientScript>();
        towerPosition = cScript.GetPosition();
        string[] splitPos = towerPosition.Split(","[0]);
        int towerX;
        int towerY;
        int.TryParse(splitPos[0], out towerX);
        int.TryParse(splitPos[1], out towerY);
        SetTower(towerX, towerY);
        return "position is " + towerX + "," + towerY;
    }


    // here is where we actually place a tower! 
    // it calls a large else-if statement that converts pixelposition to actual
    // position on gameboard (which tile it is on).
    void SetTower(int x, int y)
    {
        var pScript = posMaster.GetComponent<PixelToPosition>();
        // here we send the x,y in pixels from webcam, to the pixelmatch method
        // which will spit out a string akin to "A1", that we can switch on..
        string tile = pScript.PixelMatch(x, y);

        switch (tile)
        {
            case "A1":
                // set tower at A1
                break;
            case "None":
                // no viable position found
                break;
        }

        // etc.. we need every possible placement here as ranges of x, y coordinates! 
    }
}
