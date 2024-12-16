using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<LevelManager>().treasureList.Add(gameObject);
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelManager>().treasureList.Remove(gameObject);
    }
}
