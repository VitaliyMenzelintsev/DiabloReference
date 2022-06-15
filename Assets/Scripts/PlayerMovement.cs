using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5f;
    Camera MainCamera;
    NavMeshAgent Agent;


    public void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        MainCamera = Camera.main;
    }

    public void MoveToPoint(Vector3 _point)
    {
        Agent.SetDestination(_point);
    }
}
