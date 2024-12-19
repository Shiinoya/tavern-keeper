using UnityEngine;

public class Unit : MonoBehaviour
{
    private GameObject selectedGameObject;
    private void Awake()
    {
        selectedGameObject = transform.Find("Selected").gameObject;
    }

    public void SetSelectedVisible(bool visible)
    {
        selectedGameObject.SetActive(visible);
    }
}
