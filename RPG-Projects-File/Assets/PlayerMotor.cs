using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent navmesh;
    private void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    public void MovePoint(Vector3 point)
    {
        navmesh.SetDestination(point);
    }
}
