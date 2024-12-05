using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PartySpawnerDropZone : MonoBehaviour, IDropHandler
{
    public GameObject spawnNPC;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("SpawnNPC");
            GameObject spawn = Instantiate(spawnNPC);

            Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawn.transform.position = spawnPosition;
            FindObjectOfType<LevelManager>().partyList.Add(spawn);

            Destroy(eventData.pointerDrag.gameObject);
        }
    }
}
