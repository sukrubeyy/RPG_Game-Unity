using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent navmesh;
    public Transform target;
    private void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if(target!=null)
        {
            navmesh.SetDestination(target.position);
            targetFace();
        }
    }
    private void targetFace()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
    }

    public void MovePoint(Vector3 point)
    {
        navmesh.SetDestination(point);
    }

    public void FollowTarget(Interactable targetNEW)
    {
        navmesh.stoppingDistance = targetNEW.radius*.8f;
        navmesh.updateRotation = false;
        target = targetNEW.interactionsTransform;

    }

    public void StopTarget()
    {
        navmesh.stoppingDistance = 0f;
        navmesh.updateRotation = true;
        target = null;
    }
}
