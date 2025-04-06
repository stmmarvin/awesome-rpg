using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] float weaponRange = 2f;
    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] float weaponDamage = 20f;

    float timeSinceLastAttack = 0f;
    Transform target;
   
    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (target == null) return;

        if (!GetIsInRange())
        {
            GetComponent<Mover>().MoveTo(target.position);
        }
        else
        {
            GetComponent<Mover>().Stop();
            AttackAnimation();
        }
    }
        void AttackAnimation()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                GetComponentInChildren<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.position) < weaponRange;
    }

    public void Attack(CombatTarget combatTarget)
    {
        print("Take that you dirty peasant!");
        target = combatTarget.transform;
        target.GetComponent<Health>().TakeDamage(10);
    }
    public void Cancel()
    {
        target = null;
    }

    // Animation event
    public void Hit()
    {
        Health health = target.GetComponent<Health>();
        health.TakeDamage(weaponDamage);    
    }
        public bool GetIsRange()
        {
            return GetIsRange();
        }

    
}