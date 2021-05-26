using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    private CharacterStats myStats;
    public float attackSpeed = 1f;
    public float attackCoolDown = 0f;
    public float delayDamage = .5f;

    public event System.Action OnAttact;
    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }
    private void Update()
    {
        attackCoolDown -= Time.deltaTime;
    }
    public void Attact(CharacterStats stats)
    {
        if(attackCoolDown<=0)
        {
            StartCoroutine(doDamage(stats,delayDamage));

            if (OnAttact != null)
                OnAttact();

            attackCoolDown = 1f / attackSpeed;
        }
    }

    IEnumerator doDamage(CharacterStats stats,float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }
}
