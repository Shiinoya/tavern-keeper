using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "Archer", menuName = "NPC_AdventureAttack/Archer")]
public class NPC_ArcherAttack : NPC_AdventurerAttack
{
    public float attackRange;
    public float attackRate;
    public float attackDamge = 1;
    public float fleeRange;
    public float fleeSpeed = 1;

    private float attackCooldown;

    public override void StartAttack()
    {
        thisAdventurer.GetComponent<Animator>().SetInteger("NPCType", 1);
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
                if(dist < fleeRange && attackCooldown >= 0)
                {
                    thisAdventurer.GetComponent<AIPath>().canMove = false;
                    thisAdventurer.GetComponent<AIPath>().maxSpeed = 1;
                    thisAdventurer.transform.position = Vector2.MoveTowards(thisAdventurer.transform.position, aTarget.currentTarget.transform.position, fleeSpeed * - 0.001f);
                }
                else
                {
                    thisAdventurer.GetComponent<AIPath>().canMove = true;
                    thisAdventurer.GetComponent<AIPath>().maxSpeed = 0f;
                }
                
            }
            else
            {
                thisAdventurer.GetComponent<AIPath>().canMove = true;
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
        aTarget.currentTarget.GetComponent<HitPointManager>().EffectHealth(attackDamge);
        thisAdventurer.GetComponent<Animator>().SetTrigger("Attack");
    }
}
