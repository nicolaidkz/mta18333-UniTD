using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    private PlayerStats GameMaster;
    public GameObject towerPrefab;
    public GameObject towerPrefab2;
    private GameObject tower;
    public int cost;
    public int cost2;

    private bool CanPlaceTower()
    {
        return tower == null && GameMaster.Currency >= cost;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButton(1) && CanPlaceTower() && GameMaster.Currency >= cost2)
        {
            tower = (GameObject) Instantiate(towerPrefab2, transform.position, Quaternion.identity);
            GameMaster.Currency -= cost2;
        }


        if (CanPlaceTower())
        {
            tower = (GameObject) Instantiate(towerPrefab, transform.position, Quaternion.identity);
              GameMaster.Currency -= cost;
        }
    }

    // Use this for initialization
    void Start ()
    {
        GameMaster = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
    }
}
