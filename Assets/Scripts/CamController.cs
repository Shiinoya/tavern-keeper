using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float camSpeed = 1;
    public float camZoom = 100;

    private void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(camSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), camSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * camZoom * Time.deltaTime;
        }
    }

}
