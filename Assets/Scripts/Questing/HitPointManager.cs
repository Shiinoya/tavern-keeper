using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointManager : MonoBehaviour
{
    public float maxHP = 10;
    public float currentHP;


    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {

    }

    public void EffectHealth(float value)
    {
        currentHP -= value;

        if(currentHP > maxHP)
            currentHP = maxHP;

        if(gameObject.GetComponent<NPC_AdventurerTargeting>())
        {
            gameObject.GetComponent<NPC_AdventurerTargeting>().FindTarget();
        }

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
