using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    Camera Camera;
    private Unit selectedUnit;

    void Start()
    {
        Camera = Camera.main;

        if (selectedUnit != null)
        {
            selectedUnit = null;
        }
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
                Unit clickedUnit = hit.collider.GetComponent<Unit>();

                // if object is unit
                if (clickedUnit != null)
                {
                    // TODO : too much if() nesting
                    if (selectedUnit != null)
                    {
                        selectedUnit.SetSelected(false);

                    }

                    selectedUnit = clickedUnit;
                    selectedUnit.SetSelected(true);
                    Debug.Log("Object clicked: " + selectedUnit.name);
                }
            }

            // if no object clicked (deselect)
            if (hit.collider == null)
            {
                Debug.Log("Deselect");

                if (selectedUnit != null)
                {
                    selectedUnit.SetSelected(false);
                    selectedUnit = null;
                }

            }
        }
    }
}
