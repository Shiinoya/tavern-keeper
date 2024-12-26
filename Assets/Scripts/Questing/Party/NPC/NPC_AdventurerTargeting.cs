using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AdventurerTargeting : MonoBehaviour
{
    public GameObject currentTarget;

    void Start()
    {

    }

    void Update()
    {
        if (currentTarget == null)
            FindTarget();
        else
            GetComponent<AIDestinationSetter>().target = currentTarget.transform;
    }

    public void FindTarget()
    {
        GameObject storedEN = null;

        for (int i = 0; i < FindObjectOfType<LevelManager>().enemyList.Count; i++)
        {
            if (storedEN != null)
            {
                float storedDist = (gameObject.transform.position - storedEN.transform.position).magnitude;
                float checkDist = (gameObject.transform.position - FindObjectOfType<LevelManager>().enemyList[i].gameObject.transform.position).magnitude;
                if (checkDist < storedDist)
                {
                    storedEN = FindObjectOfType<LevelManager>().enemyList[i].gameObject;
                }
            }
            else
            {
                storedEN = FindObjectOfType<LevelManager>().enemyList[i].gameObject;
            }
        }

        GameObject storedTreasure = null;

        for (int i = 0; i < FindObjectOfType<LevelManager>().treasureList.Count; i++)
        {
            if (storedTreasure != null)
            {
                float storedDist = (gameObject.transform.position - storedTreasure.transform.position).magnitude;
                float checkDist = (gameObject.transform.position - FindObjectOfType<LevelManager>().treasureList[i].gameObject.transform.position).magnitude;
                if (checkDist < storedDist)
                {
                    storedTreasure = FindObjectOfType<LevelManager>().treasureList[i].gameObject;
                }
            }
            else
            {
                storedTreasure = FindObjectOfType<LevelManager>().treasureList[i].gameObject;
            }
        }

        if(storedTreasure != null && storedEN != null)
        {
            float enDist = (gameObject.transform.position - storedEN.transform.position).magnitude;
            float tDist = (gameObject.transform.position - storedTreasure.transform.position).magnitude;

            if(tDist * 2.5f < enDist)
            {
                currentTarget = storedTreasure;
            }
            else
            {
                currentTarget = storedEN;
            }
        }
        else if(storedTreasure != null && storedEN == null)
        {
            currentTarget = storedTreasure;
        }
        else if(storedTreasure == null && storedEN != null)
        {
            currentTarget = storedEN;
        }
        else
        {
            currentTarget = null;
        }

    }
}
