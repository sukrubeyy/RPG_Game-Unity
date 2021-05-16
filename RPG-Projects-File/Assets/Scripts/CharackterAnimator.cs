using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharackterAnimator : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    const float movementAnimatorSmoothTime = .1f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        float speedPercentparameter = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercentparameter);
      
    }
}
