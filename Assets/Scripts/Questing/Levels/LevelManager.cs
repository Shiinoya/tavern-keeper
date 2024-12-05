using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> enemyList = new List<GameObject>();

    public List<GameObject> treasureList = new List<GameObject>();

    public List<GameObject> partyList = new List<GameObject>();

    private void Update()
    {
        if (enemyList.Count <= 0 && treasureList.Count <= 0)
        {
            Debug.Log("Complete");
        }
    }
}
