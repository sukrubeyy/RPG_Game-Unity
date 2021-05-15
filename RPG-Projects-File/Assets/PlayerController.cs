using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask moveMask;
    Camera cam;
    Ray ray;
    RaycastHit hit;
    PlayerMotor motor;
    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        cam = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit,100,moveMask))
            {
                motor.MovePoint(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, moveMask))
            {
               
            }
        }

    }
}
