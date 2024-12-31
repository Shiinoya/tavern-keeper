using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartyManager : MonoBehaviour
{

    public static PartyManager Instance;

    public NPC_AdventurerAttack[] partyList;
    public NPC_AdventurerAttack[] ownedAdv;

    public GameObject storedLevel;

    public GameObject partySlot0;
    public GameObject partySlot1;
    public GameObject partySlot2;
    public GameObject partySlot3;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    public void UpdatePartyList()
    {
        if (partySlot0.GetComponent<PartySpawnerSlots>().storedAdv != null)
        {
            partyList[0] = partySlot0.GetComponent<PartySpawnerSlots>().storedAdv.npcType;
            
        }
        if (partySlot1.GetComponent<PartySpawnerSlots>().storedAdv != null)
            partyList[1] = partySlot1.GetComponent<PartySpawnerSlots>().storedAdv.npcType;
        if (partySlot2.GetComponent<PartySpawnerSlots>().storedAdv != null)
            partyList[2] = partySlot2.GetComponent<PartySpawnerSlots>().storedAdv.npcType;
        if (partySlot3.GetComponent<PartySpawnerSlots>().storedAdv != null)
            partyList[3] = partySlot3.GetComponent<PartySpawnerSlots>().storedAdv.npcType;
    }
}
