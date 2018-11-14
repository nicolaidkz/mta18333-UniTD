using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]

    public float startHealth = 100;
    private float health;

    private Transform target;
    private int wavepointIndex = 0;

    [Header("Unity specific things")]
    public Image healthBar;

    void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        healthBar.fillAmount = health / startHealth;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * startSpeed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

}
