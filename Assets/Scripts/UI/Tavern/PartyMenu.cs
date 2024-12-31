using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMenu : MonoBehaviour
{
    public GameObject partySlot;
    public GameObject partyAdvItem;
    public GameObject partySlotArea;

    private PartyManager pManager;

    private void Start()
    {
        pManager = FindObjectOfType<PartyManager>();

        OpenMenu();
    }

    public void OpenMenu()
    {
        for (int i = 0; i < pManager.ownedAdv.Length; i++)
        {
            if (pManager.ownedAdv[i] != null)
            {
                GameObject spawn = Instantiate(partyAdvItem, partySlotArea.transform);
                spawn.GetComponent<PartyManager_Adv>().npcType = pManager.ownedAdv[i];
            }

        }
    }

}
