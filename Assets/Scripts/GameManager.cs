using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    Camera Camera;
    public Unit ActiveUnit;


    // Start is called before the first frame update
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

            if (hit.collider != null)
            {
                // clicked object
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("You clicked on: " + clickedObject.name);
            }
        }
    }
}
