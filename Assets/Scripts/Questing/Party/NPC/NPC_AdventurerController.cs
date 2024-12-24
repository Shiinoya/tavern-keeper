using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AdventurerController : MonoBehaviour
{

    public NPC_AdventurerAttack npcAttack;
    private NPC_AdventurerTargeting aTarget;
    
    private void Start()
    {
        aTarget = GetComponent<NPC_AdventurerTargeting>();
        npcAttack.aTarget = aTarget;
        npcAttack.thisAdventurer = gameObject;
        npcAttack.StartAttack();
        gameObject.GetComponentInChildren<SpriteRenderer>().color = npcAttack.aColor;
    }

    private void Update()
    {
        npcAttack.UpdateAttack();
    }

}
