using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
// Variables adjustable in inspector to determine bullet speed and damage.
    public float speed = 15;
    public int damage;

// Instantiate copies of the objects and store it so we can manipulate it during the game.
    public GameObject target;
    private PlayerStats GameMaster;

// Access component of GameMaster object, PlayerStats.
    void Start()
    {
        GameMaster = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
    }

    void Update()
    {
// If there is no target, destroy gameObject and return.
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime; // Speed * time it took to complete last frame.

        if (dir.magnitude <= distanceThisFrame) // If length of vector is lesser or equal to distanceThisFrame
        {
            if (target != null)
            {
// Retrieve target's healthbar component. Reduce health by bullet's damage.
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage);

// If healthbar is less or equal 0, destroy target and award currency.
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                    if (GameObject.FindWithTag("P1_BulletOne"))
                    {
                        GameMaster.Currency += 50;
                    }
                    else if (GameObject.FindWithTag("P2_BulletTwo"))
                    {
                        GameMaster.Currency2 += 50;
                    }
                }
// Destroy bullet
                Destroy(gameObject);
            }
        }
// Moves object forward vector direction, by 1 * distanceThisFrame using world's coordinates.
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
}
