using UnityEngine;

public class Unit : MonoBehaviour
{
    private GameObject selectedUnit;
    private void Awake()
    {
        selectedUnit = transform.Find("SelectedIndicator").gameObject;
        selectedUnit.SetActive(false);
    }

    public void SetSelected(bool visible)
    {
        selectedUnit.SetActive(visible);
    }
}
