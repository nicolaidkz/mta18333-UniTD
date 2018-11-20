using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour {
    public List<GameObject> enemiesInRange;
    private float lastShotTime;

    public GameObject bullet;
    public float fireRate;

    // Use this for initialization
    void Start () {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
    }

    private void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            Enemy del =
                other.gameObject.GetComponent<Enemy>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            Enemy del =
                other.gameObject.GetComponent<Enemy>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }
    // Update is called once per frame
    void Update () {
        GameObject target = null;
        // 1
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<Enemy>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        if (target != null)
        {
            if (Time.time - lastShotTime > fireRate)
            {
                Shoot(target.GetComponent<SphereCollider>());
                lastShotTime = Time.time;
            }

        }
    }
    private void Shoot(SphereCollider target)
    {
        GameObject bulletPrefab = bullet;
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.y = bulletPrefab.transform.position.y;
        targetPosition.y = bulletPrefab.transform.position.y;

        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
    }
}
