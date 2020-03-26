/*  Unity Script for Player Firing
 *  by Gabriel Cruceanu for Group Project 2 game "Rise Against the Cuisine"
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firing : MonoBehaviour
{
    // Instantiate the Bullet Emitter and Bullet game objects to assign
    public GameObject Bullet_Emitter;
    public GameObject Bullet;

    // Declare the bullet speed and the rate of fire (the rate of fire is inversely proportional)
    public float Bullet_Speed = 40;
    public float Fire_Rate;

    // Declare the max ammo count, the current ammo, and the reload time (seconds)
    public int Max_Ammo=10;
    private int Current_Ammo;
    public float Reload_Time=3f;

    // Boolean to check if the player is reloading or not
    private bool isReloading = false;

    // Time between the first bullet shot and the next one
    private float Time_Elapsed;

    public Text Ammo_Count;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the time with 0;
        Time_Elapsed = 0;
        // At start, the current ammo is by default equal with the maximum ammo
        Current_Ammo = Max_Ammo;
    }

    // Update is called once per frame
    void Update()
    {
        Time_Elapsed = Time_Elapsed + Time.deltaTime;

        // Check if the player is reloading
        if (isReloading)
        {
            Ammo_Count.text = "Reloading...";
            return;
        }

        // Whenever the ammo drops down to or below 0, or whenever the ammo is less than the maximum ammo and the R button is pressed, reload the gun
        if (Current_Ammo <= 0 || (Current_Ammo<Max_Ammo&&Input.GetKeyDown("r")))
        {
            StartCoroutine(Reload());
            return;
        }

        // When the fire button, fire a bullet and reset the time elapsed between the first bullet shot and the next one
        if(Input.GetButton("Fire1")&& Time_Elapsed>=Fire_Rate)
        {
            Time_Elapsed = 0;
            Shoot();    
        }

        Ammo_Count.text = Current_Ammo + " / " + Max_Ammo;
    }

    void Shoot()
    {
        // Decrease the current ammo with each shot
        --Current_Ammo;

        // Instantiate bullet
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        // Bullets may appear rotated incorrectly, corrects the rotation here
        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

        // Retrieve the rigidbody component from the bullet
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        // Add forward force to the bullet so it moves
        Temporary_RigidBody.AddForce(transform.up * -Bullet_Speed);

        // Clean the bullets after 10 seconds from the moment they have been fired
        Destroy(Temporary_Bullet_Handler, 10.0f);
    }

    // While the player is reloading, set the boolean isReloading to true in order to show a text saying that the player is reloading 
    // and wait for the Reload time to pass, then assign the value of maximum ammo to the current ammo count
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(Reload_Time);
        Current_Ammo = Max_Ammo;
        isReloading = false;
    }

}
