using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    Camera Camera;
    public Unit ActiveUnit;

    void Start()
    {
        Camera = Camera.main;
    }

    void Update()
    {
        Mouse mouse = Mouse.current;

        // if mouse left (select)
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition2D = Camera.ScreenToWorldPoint(mouse.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            // if clicked object
            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Clicked: " + clickedObject.name);
            }
        }
    }
}
