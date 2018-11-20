using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 15;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float distance;
    private float startTime;

    private PlayerStats GameMaster;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameMaster");
        GameMaster = gm.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            if (target != null)
            {
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar =
                    healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage, 10);

                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                    GameMaster.Currency += 50;
                }
                Destroy(gameObject);
            }

        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }
}
