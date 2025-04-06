using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        UpdateAnimator();
    }

    public void StartMove(Vector3 destination)
    {
        GetComponent<Fighter>().Cancel();
        MoveTo(destination);
    }
    public void MoveTo(Vector3 destination)
    {
        navMeshAgent.destination = destination;
        navMeshAgent.isStopped = false;
    }


    public void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }

    }

    public void Stop()
    {
        navMeshAgent.isStopped = true;
    }


    void UpdateAnimator()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        Vector3 velocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        Animator animator = GetComponentInChildren<Animator>();
        animator.SetFloat("forwardSpeed", speed);


    }
}