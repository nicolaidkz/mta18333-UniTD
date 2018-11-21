using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
// Instantiate copies of the objects and store it so we can manipulate it during the game.
    private PlayerStats GameMaster;
    public GameObject towerPrefab;
    public GameObject towerPrefab2;
    private GameObject tower;
// Integers to store costs for the two towers.
    public int cost;
    public int cost2;

// Check if monster variable is null on node and if we have the required cost.
    private bool CanPlaceTower()
    {
        return tower == null && GameMaster.Currency >= cost;
        /////!!!!!!!!!!!// TODO. CHECK IF IT IS BETWEEN ROUNDS HERE ///!!!!!!!!!!/////
    }
// Method run when pressing mouse button down.
    void OnMouseDown()
    {
// If right mouse button is pressed and CanPlaceTower is true and you have more or equal the cost of tower 2, instantiate tower2prefab and deduct cost.
        if (Input.GetMouseButton(1) && CanPlaceTower() && GameMaster.Currency >= cost2)
        {
            tower = (GameObject) Instantiate(towerPrefab2, transform.position, Quaternion.identity);
            GameMaster.Currency -= cost2;
        }

// If CanPlaceTower is true and right mouse is not pressed, instantiate tower1prefab and deduct cost.
        if (CanPlaceTower() && Input.GetMouseButton(1) == false)
        {
            tower = (GameObject) Instantiate(towerPrefab, transform.position, Quaternion.identity);
              GameMaster.Currency -= cost;
        }
    }

// Access component of GameMaster object, PlayerStats.
    void Start ()
    {
        GameMaster = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
    }
}
