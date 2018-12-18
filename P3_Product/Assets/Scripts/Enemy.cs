using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
// Variables to store health and speed and allow for easy change in inspector.
    public float startSpeed = 10f;
    public float startHealth = 100;
    private float health;

    private Transform target;
    private int wavepointIndex = 0;


// Method to calculate which enemy is closest to goal
    public float DistanceToGoal()
    {
// Distance set to 0
        float distance = 0;
// Distance is added with Vector3 distance
        distance += Vector3.Distance(

            gameObject.transform.position, // position of enemy
            Waypoints.points[wavepointIndex].transform.position); // position of waypoint

        // Calculate start and end position of vector and calculate distance
        for (int i = wavepointIndex + 1; i < Waypoints.points.Length - 1; i++)
        {
            Vector3 startPosition = Waypoints.points[i].transform.position; // curreny waypoint
            Vector3 endPosition = Waypoints.points[i + 1].transform.position; // next waypoint
            distance += Vector3.Distance(startPosition, endPosition); // vector from curreny waypoint to next waypoint
        }
        return distance;
    }

    void Start()
    {
        target = Waypoints.points[0];      
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; // directional vector going from 0,0,0 to target

        // vector is normalized to keep direction, but have length of 1. Space.World used to use world space and not space local for object. 
        // speed * deltatime is used to base speed on time between frames, rather than real time for a smoother and more predictable / reliable game.
        transform.Translate(dir.normalized * startSpeed * Time.deltaTime, Space.World); // Moves object speed for every frame

        //if distance is less than 0.4, call getnextwaypoint
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

 // Set target to next waypoint or call endpath.
    void GetNextWaypoint()
    {
// If there are no more waypoints, call end path and return.
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++; // increase wavepoint index.
        target = Waypoints.points[wavepointIndex]; // set target to next waypoint
    }

// If enemy ends path, remove 1 life and destroy enemy.
    void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }

    public delegate void EnemyDelegate(GameObject enemy);
    public EnemyDelegate enemyDelegate;

    void OnDestroy()
    {
        if (enemyDelegate != null)
        {
            enemyDelegate(gameObject);
        }
    }
}
