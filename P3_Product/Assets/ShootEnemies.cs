using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
public class ShootEnemies : MonoBehaviour {
    public List<GameObject> enemiesInRange;

    // Use this for initialization
    void Start () {
        enemiesInRange = new List<GameObject>();

    }

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestruction del =
                other.gameObject.GetComponent<EnemyDestruction>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }
    // 3
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestruction del =
                other.gameObject.GetComponent<EnemyDestruction>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
