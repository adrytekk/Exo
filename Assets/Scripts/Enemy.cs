using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    public bool PlayerDetected = false;
    public State CurrentState;
    private NavMeshAgent agent;
    [SerializeField] Transform playerPos;
    public static GameObject[] Waypoints;
    public bool isReached = false;
    public bool isGoing = false;
    


    public enum State
    {
      Idle, 
      Chase,
      Search,
    }
    
    void Start()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Destination");
        agent = GetComponent<NavMeshAgent>();
        PlayerDetected = false;
        CurrentState = State.Idle;
    }

    public void Update()
    {
        if (agent.isStopped)
        {
            isReached = true;
        }
        
        switch (CurrentState)
        {
            case State.Idle:
                Idle();
                if (PlayerDetected == true) CurrentState = State.Chase;
            {
                    
                }
                
                break;
            case State.Chase:
                Chase();
                if (PlayerDetected == false) CurrentState = State.Search;

                break;
            case State.Search:
                Chase();
                if (PlayerDetected == true) CurrentState = State.Chase;

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDetected = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDetected = false;
        }
    }

    public void Idle()
    {
        isGoing = true;
        isReached = false;
    }

    public void Chase()
    {
        agent.SetDestination(playerPos.position);
    }

    public void Search()
    {
        
    }
}
