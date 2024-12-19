using UnityEngine;

public class Unit : MonoBehaviour
{
    private GameObject selectedUnit;
    
    private Vector2 targetPosition;
    private bool isMoving = false;
    private readonly float moveSpeed = 8f;

    private void Awake()
    {
        selectedUnit = transform.Find("SelectedIndicator").gameObject;
        selectedUnit.SetActive(false);
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        if (transform.position == (Vector3)targetPosition)
        {
            isMoving = false;
        }
    }

    public void SetSelected(bool visible)
    {
        selectedUnit.SetActive(visible);
    }

    public void Move(Vector2 position)
    {
        targetPosition = position;
        isMoving = true;
    }
}
