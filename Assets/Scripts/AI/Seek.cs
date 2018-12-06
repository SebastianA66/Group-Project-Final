using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seek : MonoBehaviour
{
    public NavMeshAgent navmesh;
    public Transform target;
    public float speed = 10;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // makes that target finds player then gets the transform of player
        navmesh = this.GetComponent<NavMeshAgent>(); // sets this object to be the navmesh agent (this isn't needed but helps for understanding)
    }

    void Update()
    {
        navmesh.SetDestination(target.position); // this sets the enemy to grab the targets position, and set it's destination to it.
    }
}
