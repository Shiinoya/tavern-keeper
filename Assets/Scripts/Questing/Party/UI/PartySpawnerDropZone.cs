using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PartySpawnerDropZone : MonoBehaviour, IDropHandler
{
    public GameObject spawnNPC;

    public LayerMask obsticleLayers;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit)
            {
                if(hit.collider.gameObject.layer == 6)
                {
                    Debug.Log("Spawn Fail");
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector3(50, -50, 0);
                }
                else
                {
                    Debug.Log("Safe Hit");
                    Debug.Log("SpawnNPC");
                    GameObject spawn = Instantiate(spawnNPC);

                    Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawn.transform.position = spawnPosition;
                    spawn.GetComponent<NPC_AdventurerController>().npcAttack = eventData.pointerDrag.GetComponent<PartySpawner>().npcType;
                    FindObjectOfType<LevelManager>().partyList.Add(spawn);

                    Destroy(eventData.pointerDrag.gameObject);
                }
            }
            else
            {
                Debug.Log("Nothing hit");
                Debug.Log("SpawnNPC");
                GameObject spawn = Instantiate(spawnNPC);

                Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawn.transform.position = spawnPosition;
                spawn.GetComponent<NPC_AdventurerController>().npcAttack = eventData.pointerDrag.GetComponent<PartySpawner>().npcType;
                FindObjectOfType<LevelManager>().partyList.Add(spawn);

                Destroy(eventData.pointerDrag.gameObject);
            }

        }
    }
}
