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
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
