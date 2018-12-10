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
                Debug.Log("entered OnMouseDown");
                GetPosition();
               
                /*
            tower = (GameObject) Instantiate(towerPrefab2, transform.position, Quaternion.identity);
            GameMaster.Currency -= cost2;

                */
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
        Debug.Log("entered GetPosition");
        var cScript = posMaster.GetComponent<ClientScript>();
        towerPosition = cScript.GetPosition();
        Debug.Log("before split: " +towerPosition);

        string tempTowerPos = towerPosition.Replace("[", string.Empty);
        Debug.Log("after [ removal: " + tempTowerPos);

        string temp2TowerPos = tempTowerPos.Replace("]]", string.Empty);
        Debug.Log("after ]] removal: " + temp2TowerPos);

        string temp3TowerPos = temp2TowerPos.Replace("],", ":");
        Debug.Log("after ], removal: " + temp3TowerPos);

        string[] towerArrayPos = temp3TowerPos.Split(":"[0]);
        Debug.Log("after splitting it into array positions pos 0: " + towerArrayPos[0] + " pos 1: " + towerArrayPos[1] + " pos 2: " + towerArrayPos[2] + " pos 3: " + towerArrayPos[3]);

        string[] splitPosP1T1 = towerArrayPos[0].Split(","[0]);
        Debug.Log("after splitting pos 0 into P1T1 pos 0: " + splitPosP1T1[0] + " and pos 1: " + splitPosP1T1[1]);

        string[] splitPosP1T2 = towerArrayPos[1].Split(","[0]);
        Debug.Log("after splitting pos 1 into P1T2 pos 0: " + splitPosP1T2[0] + " and pos 1: " + splitPosP1T2[1]);

        string[] splitPosP2T1 = towerArrayPos[2].Split(","[0]);
        Debug.Log("after splitting pos 2 into P2T1 pos 0: " + splitPosP2T1[0] + " and pos 1: " + splitPosP2T1[1]);

        string[] splitPosP2T2 = towerArrayPos[3].Split(","[0]);
        Debug.Log("after splitting pos 3 into P2T2 pos 0: " + splitPosP2T2[0] + " and pos 1: " + splitPosP2T2[1]);


        int towerP1T1X;
        int towerP1T1Y;
        int.TryParse(splitPosP1T1[0], out towerP1T1X);
        int.TryParse(splitPosP1T1[1], out towerP1T1Y);
        Debug.Log("after int conv: " + towerP1T1X + "," + towerP1T1Y);
        SetTower(towerP1T1X, towerP1T1Y);
        return "position is " + towerP1T1X + "," + towerP1T1Y;
    }


    // here is where we actually place a tower! 
    // it calls a large else-if statement that converts pixelposition to actual
    // position on gameboard (which tile it is on).
    void SetTower(int x, int y)
    {
        Debug.Log("position is: " + x + "," + y);
        var pScript = posMaster.GetComponent<PixelToPosition>();
        // here we send the x,y in pixels from webcam, to the pixelmatch method
        // which will spit out a string akin to "A1", that we can switch on..
        string tile = pScript.PixelMatch(x, y);

        if (tile != "None")
        {
            // instantiate a tower on tile
            tower = (GameObject)Instantiate(towerPrefab, GameObject.FindGameObjectWithTag(tile).transform.position, Quaternion.identity);
            // remove currency from player
            GameMaster.Currency -= cost;
        }
        else { Debug.Log("No viable placement"); }

        // etc.. we need every possible placement here as ranges of x, y coordinates! 
    }
}


 