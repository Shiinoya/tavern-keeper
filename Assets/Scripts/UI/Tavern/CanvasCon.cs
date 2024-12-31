using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCon : MonoBehaviour
{
    public GameObject startQuestButton;
    public GameObject partyPanel;
    public GameObject questPanel;

    private void Update()
    {
        if(!partyPanel.activeSelf && !questPanel.activeSelf)
        {
            startQuestButton.SetActive(true);
        }
        else
        {
            startQuestButton.SetActive(false);
        }

    }

    public void OpenPartyMenu()
    {
        partyPanel.SetActive(true);
    }

    public void ClosePartyMenu()
    {
        partyPanel.SetActive(false);
    }

    public void OpenQuestMenu()
    {
        questPanel.SetActive(true);
        ClosePartyMenu();
    }

    public void CloseQuestMenu()
    {
        questPanel.SetActive(false);
    }

}
