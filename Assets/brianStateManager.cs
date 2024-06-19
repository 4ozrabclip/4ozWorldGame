using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BrianStateManager : MonoBehaviour
{
    public enum State{
        PASSIVE,
        AGGRESIVE
    }
    public State state;

    public bool brianHome = true;
    private NavMeshAgent agent;
    private Animator animator;
    public Transform player; // Reference to the player
    private Vector3 originalPosition;
    public Collider homeBox;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        originalPosition = transform.position; // Store the original position
    }
    public void setBrianHome(bool homeOrNot){
        brianHome = homeOrNot;
    }
    void Update()
    {
        if(state == State.PASSIVE){
            UpdatePassive();
        }
        else if(state == State.AGGRESIVE){
            UpdateAggresive();
        }

    }
    private void UpdatePassive(){
        bool isPlayerWithinNavMesh = IsPlayerWithinNavMesh();

        if(isPlayerWithinNavMesh){
            state = State.AGGRESIVE;
        }
        else{
            agent.SetDestination(originalPosition);
            animator.SetBool("walkPatrol", !brianHome);
        }
    }
    private void UpdateAggresive(){
        bool isPlayerWithinNavMesh = IsPlayerWithinNavMesh();

        if(!isPlayerWithinNavMesh){
            state = State.PASSIVE;
        }
        else{
            setBrianHome(false);
            animator.SetBool("walkPatrol", true);
            agent.SetDestination(player.position);        }
    }

    bool IsPlayerWithinNavMesh()
    {
        // Check if the player's position is on the NavMesh
        NavMeshHit hit;
        return NavMesh.SamplePosition(player.position, out hit, 1f, NavMesh.AllAreas);
    }
}