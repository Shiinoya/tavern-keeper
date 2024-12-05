using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject currentTarget;

    public float enRange = 3;

    void Start()
    {
        
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
        
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelManager>().enemyList.Remove(gameObject);
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
