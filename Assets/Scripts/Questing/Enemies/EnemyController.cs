using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public GameObject currentTarget;

    public float enRange = 3;

    public float attackRange;
    public float attackRate;
    public float attackDamge = 1;

    private float attackCooldown;

    void Start()
    {
        FindObjectOfType<LevelManager>().enemyList.Add(gameObject);
    }

    void Update()
    {
        if(currentTarget == null)
        {
            FindTarget();
        }

        if(currentTarget != null)
        {
            GetComponent<AIDestinationSetter>().target = currentTarget.transform;
        }
        else
        {
            GetComponent<AIDestinationSetter>().target = null;
        }

        if (currentTarget != null)
        {
            float dist = (currentTarget.transform.position - transform.position).magnitude;

            if (dist < attackRange && attackCooldown <= 0)
            {
                AttackTarget();
                attackCooldown = attackRate;
            }
        }

        if (attackCooldown > 0)
        {
            attackCooldown -= 1 * Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelManager>().enemyList.Remove(gameObject);
    }

    public void AttackTarget()
    {
        currentTarget.GetComponent<HitPointManager>().EffectHealth(attackDamge);
    }

    public void FindTarget()
    {
        GameObject storedEN = null;

        if(FindObjectOfType<LevelManager>().partyList.Count > 0)
        {
            for (int i = 0; i < FindObjectOfType<LevelManager>().partyList.Count; i++)
            {
                if (storedEN != null)
                {
                    float storedDist = (gameObject.transform.position - storedEN.transform.position).magnitude;
                    float checkDist = (gameObject.transform.position - FindObjectOfType<LevelManager>().partyList[i].gameObject.transform.position).magnitude;
                    if (checkDist < storedDist)
                    {
                        if (checkDist < enRange)
                            storedEN = FindObjectOfType<LevelManager>().partyList[i].gameObject;
                    }
                }
                else
                {
                    float checkDist = (gameObject.transform.position - FindObjectOfType<LevelManager>().partyList[i].gameObject.transform.position).magnitude;
                    if (checkDist < enRange)
                        storedEN = FindObjectOfType<LevelManager>().partyList[i].gameObject;
                }
            }
        }

        currentTarget = storedEN;

    }
}
