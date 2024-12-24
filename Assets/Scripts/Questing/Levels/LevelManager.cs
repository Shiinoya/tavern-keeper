using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> enemyList = new List<GameObject>();

    public List<GameObject> treasureList = new List<GameObject>();

    public List<GameObject> partyList = new List<GameObject>();

    private PartyManager partyManager;

    public GameObject partySpawner;
    public GameObject partySlot;
    public GameObject slotSection;

    private void Start()
    {
        partyManager = FindObjectOfType<PartyManager>();

        for (int i = 0; i < partyManager.partyList.Length; i++)
        {
            if (partyManager.partyList[i] != null)
            {
                GameObject slotSpawn = Instantiate(partySlot, slotSection.transform);
                GameObject partySpawn = Instantiate(partySpawner, slotSpawn.transform);
                partySpawn.GetComponent<PartySpawner>().npcType = partyManager.partyList[i];
                partySpawn.GetComponent<RectTransform>().anchoredPosition = new Vector3(50, -50, 0);
            }
        }
    }


    private void Update()
    {
        if (enemyList.Count <= 0 && treasureList.Count <= 0)
        {
            Debug.Log("Complete");
        }
    }
}
