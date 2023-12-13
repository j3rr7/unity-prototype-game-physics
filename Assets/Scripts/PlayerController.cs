using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float health = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        Debug.Log("Applying damage: " + damage);

        health -= damage;
        if (health <= 0)
            health = 0;

        Debug.Log("Current health: " + health);

        // gameover logic
        if (health == 0)
        {
            Debug.Log("Game over");
        }
    }
}
