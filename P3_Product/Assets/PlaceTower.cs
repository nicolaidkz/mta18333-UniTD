using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour {
    public GameObject towerPrefab;
    private GameObject tower;

    private bool CanPlaceTower()
    {
        return tower == null;
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
        }
        else if (CanUpgradeTower())
        {
            tower.GetComponent<TowerData>().IncreaseLevel();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
