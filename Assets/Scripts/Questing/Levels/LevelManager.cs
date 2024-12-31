using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> enemyList = new List<GameObject>();

    public List<GameObject> treasureList = new List<GameObject>();

    public List<GameObject> partyList = new List<GameObject>();

    public Animator uiAni;

    public GameObject partySpawner;
    public GameObject partySlot;
    public GameObject slotSection;

    private PartyManager partyManager;

    private float loadTimer = 3f;

    private void Start()
    {
        partyManager = FindObjectOfType<PartyManager>();

        if(partyManager.storedLevel != null)
            Instantiate(partyManager.storedLevel);

        FindObjectOfType<AstarPath>().Scan();

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
        //temp fix for ending level straight away
        if(loadTimer > 0)
            loadTimer -= Time.deltaTime;

        if (enemyList.Count <= 0 && treasureList.Count <= 0 && loadTimer <= 0)
        {
            uiAni.SetBool("LevelComplete", true);
        }
    }
}
