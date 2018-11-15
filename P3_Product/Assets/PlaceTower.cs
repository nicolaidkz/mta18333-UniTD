using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    private CurrencyManagerBehavior currencyManager;
    public GameObject towerPrefab;
    private GameObject tower;

    private bool CanPlaceTower()
    {
        int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;
        return tower == null && currencyManager.Currency >= cost;
    }

    private bool CanUpgradeTower()
    {
        if (tower != null)
        {
            TowerData towerData = tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.GetNextLevel();
            if (nextLevel != null)
            {
                return true;
            }
        }
        return false;
    }

    void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            tower = (GameObject)
              Instantiate(towerPrefab, transform.position, Quaternion.identity);
              currencyManager.Currency -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
        else if (CanUpgradeTower())
        {
            tower.GetComponent<TowerData>().IncreaseLevel();
        }
    }

    // Use this for initialization
    void Start ()
    {
        currencyManager = GameObject.Find("CurrencyManager").GetComponent<CurrencyManagerBehavior>();
    }
}
