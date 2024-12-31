using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "Knight", menuName = "NPC_AdventureAttack/Knight")]
public class NPC_KnightAttack : NPC_AdventurerAttack
{
    public float attackRange;
    public float attackRate;
    public float attackDamge = 1;

    private float attackCooldown;

    public override void StartAttack()
    {
        thisAdventurer.GetComponent<Animator>().SetInteger("NPCType", 0);
    }

    public override void UpdateAttack()
    {

        if (aTarget.currentTarget != null)
        {
            float dist = (aTarget.currentTarget.transform.position - thisAdventurer.transform.position).magnitude;

            if (dist < attackRange && attackCooldown <= 0)
            {
                AttackTarget();
                attackCooldown = attackRate;
            }

            if (dist < attackRange)
            {
                thisAdventurer.GetComponent<AIPath>().maxSpeed = 0.2f;
            }
            else
            {
                thisAdventurer.GetComponent<AIPath>().maxSpeed = 1;
            }

        }

        if (attackCooldown > 0)
        {
            attackCooldown -= 1 * Time.deltaTime;
        }
    }

    public override void EndAttack() 
    {
        
    }

    public void AttackTarget()
    {
        thisAdventurer.GetComponent<Animator>().SetTrigger("Attack");
        aTarget.currentTarget.GetComponent<HitPointManager>().EffectHealth(attackDamge);
    }
}
