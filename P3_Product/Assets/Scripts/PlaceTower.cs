﻿using System.Collections;
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
// Integers to store costs for the two towers.
    public int cost;
    public int cost2;

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
    }
}