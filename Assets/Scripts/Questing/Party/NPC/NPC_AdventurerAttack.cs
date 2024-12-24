using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC_AdventurerAttack : ScriptableObject
{
    public NPC_AdventurerTargeting aTarget;
    public GameObject thisAdventurer;
    public Color aColor;

    public abstract void StartAttack();

    public abstract void UpdateAttack();

    public abstract void EndAttack();

}
