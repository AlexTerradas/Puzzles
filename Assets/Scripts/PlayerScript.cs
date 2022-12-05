using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 newPosition;

    void Start()
    {
        Vector3 newPosition = transform.position;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Vector3 localPos = new Vector3(newPosition.x, 0, 0);
                ////Vector3 mousePos = new Vector3(Input.mousePosition., 0, 0);
                //print(mousePos);

                //newPosition = Vector3.Lerp(localPos, mousePos, 1.5f);
                ////newPosition.y = Input.mousePosition.y;
                //transform.position = newPosition;
            }
        }

    }

}

