/*  Unity Script for Enemy Health and Taking Damage
 *  by Gabriel Cruceanu for Group Project 2 game "Rise Against the Cuisine"
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Initialize the starting health of enemies and declare the variable for enemy's current health
    public int startingHealth = 100;
    public int currentHealth;

    void Start()
    {
        // Initialize the current health with the starting health upon entering the scene
        currentHealth = startingHealth;
    }

    void OnTriggerEnter(Collider collision)
    {
        // When the bullet touches the enemy substract a random amount of health from the enemy's current health
        if (collision.gameObject.tag=="Bullet")
        {
            currentHealth -= Random.Range(15, 25);
        }

        // If the enemy's health is equal to 0 or drops below 0, call the Death method
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        //Destroys the game object instantly;
        WaveSystem.EnemiesAlive--;
        Destroy(gameObject);


        // possible add-ons: sound effects, particle effects, animations, etc.
    }
}
