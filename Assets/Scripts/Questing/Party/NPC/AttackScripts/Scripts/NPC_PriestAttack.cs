using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "Priest", menuName = "NPC_AdventureAttack/Priest")]
public class NPC_PriestAttack : NPC_AdventurerAttack
{
    public float attackRange;
    public float attackRate;
    public float attackDamge = 1;
    public float healAmount = 1;
    public float healRate = 1;
    public float healRange = 1;

    private float attackCooldown;
    private float healCooldown;
    private LevelManager levelManager;

    public override void StartAttack()
    {
        levelManager = FindObjectOfType<LevelManager>();
        thisAdventurer.GetComponent<Animator>().SetInteger("NPCType", 2);
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
                thisAdventurer.GetComponent<AIPath>().maxSpeed = 0.1f;
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

        if(healCooldown <= 0)
        {
            for (int i = 0; i < FindObjectOfType<LevelManager>().partyList.Count; i++)
            {
                if (levelManager.partyList[i] != null)
                {
                    float allyDist = (thisAdventurer.transform.position - levelManager.partyList[i].transform.position).magnitude;

                    if (allyDist <= healRange && levelManager.partyList[i].GetComponent<HitPointManager>().currentHP < levelManager.partyList[i].GetComponent<HitPointManager>().maxHP)
                    {
                        levelManager.partyList[i].GetComponent<HitPointManager>().EffectHealth(-healAmount);
                        healCooldown = healRate;

                        Debug.Log("Healed: " + levelManager.partyList[i].name);
                    }
                }
            }
        }
        else
        {
            healCooldown -= 1 * Time.deltaTime;
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
