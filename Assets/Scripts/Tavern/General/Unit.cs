using UnityEngine;
using Pathfinding;

public class Unit : MonoBehaviour
{
    private GameObject selectedUnit;
    public bool isMovable = false;

    // private Vector2 targetPosition;
    public Transform targetPosition;
    private bool isMoving = false;
    private readonly float moveSpeed = 8f;

    private void Awake()
    {
        selectedUnit = transform.Find("SelectedIndicator").gameObject;
        selectedUnit.SetActive(false);
    }

    private void Start() {
        Seeker seeker = GetComponent<Seeker>();

        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
    }

    private void FixedUpdate()
    {
        // if (isMoving)
        // {
        //     transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // }

        // if (transform.position == (Vector3)targetPosition)
        // {
        //     isMoving = false;
        // }
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
    }

    public void SetSelected(bool visible)
    {
        selectedUnit.SetActive(visible);
    }

    public void Move(Vector2 position)
    {
        if (isMovable)
        {
            // targetPosition = position;
            isMoving = true;
        }
    }
}
