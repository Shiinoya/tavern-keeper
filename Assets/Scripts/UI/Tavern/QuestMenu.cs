using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenu : MonoBehaviour
{
    public Image[] levelButtons;

    public void ChangeLevel(GameObject level)
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].color = Color.white;
        }

        FindObjectOfType<PartyManager>().storedLevel = level;
    }

    public void ThisButton(Image button)
    {
        button.color = Color.yellow;
    }
}
