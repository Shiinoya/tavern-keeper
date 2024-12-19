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

        // if mouse left
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition2D = Camera.ScreenToWorldPoint(mouse.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            // if object clicked (select)
            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Object clicked: " + clickedObject.name);
                // TODO : select object
            }

            // if no object clicked (deselect)
            if (hit.collider != null)
            {
                Debug.Log("No object clicked");
                // TODO : deselect object
            }
        }
    }
}
