using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

        // if mouse left click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition2D = Camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            // if object clicked (select)
            if (hit.collider != null)
            {
                Unit clickedObject = hit.collider.GetComponent<Unit>();

                // if object is Unit: clear previously selected Unit if it exists
                if (clickedObject != null && selectedUnit != null)
                {
                    selectedUnit.SetSelected(false);
                }

                // if object is Unit: select new Unit
                if (clickedObject != null)
                {
                    selectedUnit = clickedObject;
                    selectedUnit.SetSelected(true);
                }
            }

            // if no object clicked (deselect)
            if (hit.collider == null)
            {
                if (selectedUnit != null)
                {
                    selectedUnit.SetSelected(false);
                    selectedUnit = null;
                }

            }
        }

        // if mouse right click
        if (Input.GetMouseButtonDown(1))
        {
            if (selectedUnit == null)
            {
                return;
            }

            if (selectedUnit != null)
            {
                Vector2 mousePosition2D = Camera.ScreenToWorldPoint(Input.mousePosition);
                selectedUnit.Move(mousePosition2D);
            }
        }
    }

    public void QuestScene()
    {
        SceneManager.LoadScene(1);
    }


}
