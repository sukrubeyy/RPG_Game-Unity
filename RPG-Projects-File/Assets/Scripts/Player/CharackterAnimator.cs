using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharackterAnimator : MonoBehaviour
{
    NavMeshAgent agent;
    protected Animator animator;
    const float movementAnimatorSmoothTime = .1f;
    protected CharacterCombat combat;
    protected AnimatorOverrideController overideController;
    protected AnimationClip[] currentAnimationAttackSet;
    public AnimationClip replaceAttackAnim;
    public AnimationClip[] defaultAnimationSet;
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();
        overideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overideController;

        currentAnimationAttackSet = defaultAnimationSet;
    }
    protected virtual private void Update()
    {
        float speedPercentparameter = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercentparameter);
        animator.SetBool("inCombat",combat.inCombat);
        combat.OnAttact += OnAttack;
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("Attack");
        int attackIndex = Random.Range(0, currentAnimationAttackSet.Length);
        overideController[replaceAttackAnim.name] = currentAnimationAttackSet[attackIndex];
    }
}
