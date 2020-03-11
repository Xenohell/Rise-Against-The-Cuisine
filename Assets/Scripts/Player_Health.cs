using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health: MonoBehaviour
{
    public Text p_health_Text;
    public Slider p_health_bar_slider;
    public float p_current_health;
    public float p_max_health;
    public GameObject testbox;

    // Added by Gabriel Cruceanu
    // variables for continous damage to the player if the player keeps colliding with an enemy
    float time_colliding;
    public float timeThreshold = 1f;
    public float regen = 10;
    float regen_time;
    public float regenThreshold = 1f;
    //

    void Start()
    {
        p_current_health = p_max_health;
        p_health_bar_slider.value = ChangeHealth();
    }
    
    void Update()
    {
        p_health_bar_slider.value = ChangeHealth();
        p_health_Text.text = "" + p_current_health + "%";

        if(p_current_health <= 0)
        {
            Destroy(testbox);
        }
    }

    float ChangeHealth()
    {
        return p_current_health / p_max_health;
    }

    // Added by Gabriel Cruceanu
    // Three methods, one for the moment when the player starts colliding with the enemy one for when the player is continously colliding,
    // and one for substracting the amount from the player's health
    void OnTriggerEnter(Collider collision)
    {
        // Checks if the player has collided with enemies
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Touched");
            // Reset the timer to 0
            time_colliding = 0f;
            // Deal a random amount of damage to the player
            PlayerDamage(Random.Range(4, 7));
        }
    }

    void OnTriggerStay(Collider collision)
    {
        // Checks if the player has collided with enemies
        if (collision.CompareTag("Enemy"))
        {
            // Add delta time if the time is below the threshold
            if (time_colliding < timeThreshold)
                time_colliding += Time.deltaTime;
            else
            {
                // When the timer goes over the threshold, deals random amount of damage to the player and then resets the timer
                PlayerDamage(Random.Range(4, 7));
                time_colliding = 0f;
            }
        }

        if (collision.CompareTag("Regen"))
        {
            if (regen_time < regenThreshold)
                regen_time += Time.deltaTime;
            else
            {
                if (p_current_health < p_max_health)
                {
                    p_current_health += regen;
                    regen_time=0f;
                }
                    
                if (p_current_health >= p_max_health)
                    p_current_health = p_max_health;
            }
        }
    }

    void PlayerDamage(float amount)
    {
        // Substract the amount of damage from the player's current health
        p_current_health -= amount;
        // If the player's health is below 0, set the health to 0 (so it doesn't appear with negative values) and the player dies
        if(p_current_health<=0)
        {
            p_current_health = 0;
            Debug.Log("You died");
        }
    }

}