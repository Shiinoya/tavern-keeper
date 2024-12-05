using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AdventurerController : MonoBehaviour
{
    private NPC_AdventurerTargeting aTarget;

    public float attackRange;
    public float attackRate;
    public float attackDamge = 1;

    private float attackCooldown;

    private void Start()
    {
        aTarget = GetComponent<NPC_AdventurerTargeting>();
    }

    private void Update()
    {
        if (aTarget.currentTarget != null)
        {
            float dist = (aTarget.currentTarget.transform.position - transform.position).magnitude;

            if (dist < attackRange && attackCooldown <= 0)
            {
                AttackTarget();
                attackCooldown = attackRate;
            }
            
        }

        if(attackCooldown > 0)
        {
            attackCooldown -= 1 * Time.deltaTime;
        }
    }

    public void AttackTarget()
    {
        aTarget.currentTarget.GetComponent<HitPointManager>().currentHP -= attackDamge;
    }

}
