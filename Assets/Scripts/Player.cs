/*  Unity Script for Player Camera and  Movement
 *  by Gabriel Cruceanu for Group Project 2 game "Rise Against the Cuisine"
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Declare the camera pivot
    public Transform camPivot;
    public Transform cam;

    // Third Person view and Zoomed view cameras
    public Camera ThirdPerson, Zoomed;

    // Initialize the camera tilt and rotation
    float yaw = 0;
    float pitch = 0;

    // Boolean variable to check if the player should sprint or not
    bool sprint = false;
    // Boolean variable to check if the player touches the ground
    bool isGrounded = true;

    Vector2 move;
    Rigidbody player;

    private void Start()
    {
        // Hide the mouse cursor when playing
        Cursor.visible=false;

        player = GetComponent<Rigidbody>();
        ThirdPerson.gameObject.SetActive(true);
    }

    void Update()
    {
        // While the Right Mouse Button is down, the view is zoomed in
        // On release, the camera goes back to the Third Person view
        if (Input.GetButtonUp("Fire2"))
        {
            Zoomed.gameObject.SetActive(false);
            ThirdPerson.gameObject.SetActive(true);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Zoomed.gameObject.SetActive(true);
            ThirdPerson.gameObject.SetActive(false);
        }

        Movement();
    }

    void Movement()
    {
        // Camera rotation upon mouse movement left to right
        yaw += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        // Camera tilting upon mouse movement up and down
        pitch -= Input.GetAxis("Mouse Y") * Time.deltaTime * 180;
        // Limit the camera tilting to 40 degrees up and 40 degrees down
        pitch = Mathf.Clamp(pitch, -40, +50);
        // Apply the camera rotation and tilting to the main camera
        camPivot.rotation = Quaternion.Euler(pitch, yaw, 0);

        // Instantiate movement 
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        move = Vector2.ClampMagnitude(move, 1);

        // Initialize camera looking direction
        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
       
        // Check if the player should sprint or not
        if (Input.GetKeyDown(KeyCode.LeftShift)&&move.y>0) 
            sprint=true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            sprint=false;

        // Player movement speed for sprinting and running speed
        if(sprint) transform.position += 3 * (camF * move.y + camR * move.x) * Time.deltaTime * 5;
        if(!sprint) transform.position += 2* (camF * move.y + camR * move.x) * Time.deltaTime * 5;

        // If the player touches the ground, the player is able to jump
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            player.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay()
    {
        //Set the boolean back to true whenever the player collides with the ground
        isGrounded = true;
    }

}