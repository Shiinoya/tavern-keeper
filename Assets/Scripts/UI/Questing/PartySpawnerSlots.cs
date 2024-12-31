using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PartySpawnerSlots : MonoBehaviour, IDropHandler
{
    public bool isFull = false;

    public PartyManager_Adv storedAdv;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (FindObjectOfType<PartyManager>().partySlot0 == null)
                FindObjectOfType<PartyManager>().partySlot0 = gameObject;
            else if (FindObjectOfType<PartyManager>().partySlot1 == null)
                FindObjectOfType<PartyManager>().partySlot1 = gameObject;
            else if (FindObjectOfType<PartyManager>().partySlot2 == null)
                FindObjectOfType<PartyManager>().partySlot2 = gameObject;
            else if (FindObjectOfType<PartyManager>().partySlot3 == null)
                FindObjectOfType<PartyManager>().partySlot3 = gameObject;
        }
    }

    private void Update()
    {
        if(storedAdv != null && isFull)
        {
            if(storedAdv.isClicked)
            {
                isFull = false;
                storedAdv = null;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !isFull) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = GetComponent<RectTransform>().transform.position;
            isFull = true;
            storedAdv = eventData.pointerDrag.GetComponent<PartyManager_Adv>();
        }
    }
}
