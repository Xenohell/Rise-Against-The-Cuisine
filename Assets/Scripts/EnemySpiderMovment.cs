using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpiderMovment : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    public GameObject home;
    Transform player;

    public int startHealth = 100;
    private int currentHealth;

    float dist;

    void Start()
    {
        //This sets the player value
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //This sets the home value to it's spawn point
        

        currentHealth = startHealth;

        //This sets the target to the player
        target = player;
        
        agent = GetComponent<NavMeshAgent>();

        //This starts a repeating function that starts after 0 seconds and repeats every 0.5 seconds i.e. 2 times a second
        //This is used instead of putting the code in the update function so that it is not run 60 times a second
        //InvokeRepeating("retreat", 0f, 0.5f);

    }


    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation
                                              , Quaternion.LookRotation(target.position - transform.position)
                                              , 5 * Time.deltaTime);

        if (currentHealth <= 30)
        {
            target = home.transform;
            agent.speed = 5f;
        }

        if (currentHealth >= 100)
        {
            //Debug.Log("Attack!");
            target = player;
            agent.speed = 3.5f;
        }

        if (dist > agent.stoppingDistance)
        {
            agent.SetDestination(target.position);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        // When the bullet touches the enemy substract a random amount of health from the enemy's current health
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= Random.Range(8, 14);
        }

        // If the enemy's health is equal to 0 or drops below 0, call the Death method
        //if (currentHealth <= 0)
            //Death();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Home"))
        {
            currentHealth = 100;
        }
    }




}