using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    private PlayerStats GameMaster;
    public GameObject towerPrefab;
    private GameObject tower;
    public int cost;

    private bool CanPlaceTower()
    {
        return tower == null && GameMaster.Currency >= cost;
    }

    void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            tower = (GameObject)
              Instantiate(towerPrefab, transform.position, Quaternion.identity);
              GameMaster.Currency -= cost;
        }
    }

    // Use this for initialization
    void Start ()
    {
        GameMaster = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
    }
}
