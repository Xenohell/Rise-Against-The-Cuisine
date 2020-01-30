using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;

    public float stoppingRadius = 5;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation
                                              , Quaternion.LookRotation(target.position - transform.position)
                                              , 5 * Time.deltaTime);

        
        agent.SetDestination(target.position);
        
    }
}
