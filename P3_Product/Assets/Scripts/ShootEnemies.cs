using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour {
// Adding variable to keep track of enemies in range, to keep track of last shot time, store fire rate and instantiate a copy of object.
    public List<GameObject> enemiesInRange;
    private float lastShotTime;
    public GameObject bullet;
    public float fireRate;

// Initialize enemiesInRange field and set lastShotTime to current time.
    void Start () {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
    }

// OnEnemyDestroy remove enemy from enemiesInRange.
    private void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

// When an object with tag "Enemy" enters trigger, add it to enemiesInRange. Add OnEnemyDestroy to enemyDelegate so it is called when enemy is destroyed.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            Enemy del = other.gameObject.GetComponent<Enemy>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

// When object with tag "Enemy" exits trigger, remove it from enemiesInRange. Unregister Delegate.
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            Enemy del = other.gameObject.GetComponent<Enemy>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    void Update () {
        GameObject target = null;
// Determine target of tower. Iterate over all enemies in range and chose enemy furthest along waypoints.
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
// If there is a target. Call Shoot if LastShotTime is greater than firerate and set lastShotTime to current time.
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
// Get start and target position of bullet.
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;

// Instantiate new bullet and assign start and target possition.
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;                           // Start position is position of the object copy.
        BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
        bulletComp.target = target.gameObject;                                  // Target position is position target object.
    }
}
