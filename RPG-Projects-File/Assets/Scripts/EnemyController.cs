using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float radius = 10f;
    // Start is called before the first frame update
    Transform targetTransform;
    NavMeshAgent navmeshAgent;
    CharacterCombat combat;
    void Start()
    {
        targetTransform = PlayerManager.instance.player;
        navmeshAgent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetTransform.position);
        if(distance<=radius)
        {
            navmeshAgent.SetDestination(targetTransform.position);
        }

        if(distance<=navmeshAgent.stoppingDistance)
        {
            //Attack part
            CharacterStats playerStats = targetTransform.GetComponent<CharacterStats>();
            if(playerStats!=null)
            {
                combat.Attact(playerStats);
            }
         
            RotateFace();
        }
    }

    void RotateFace()
    {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRot,Time.deltaTime*5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
