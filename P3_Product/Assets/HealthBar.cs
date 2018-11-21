using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
// Variables to hold health info, made public for easy adjustment in inspector 
    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;

// Stores the original scale of the object.
    void Start () {
        originalScale = gameObject.transform.localScale.x;
    }
	
 // Create a temporary localScale and calculate new x scale based on the current health.
	void Update () {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}
