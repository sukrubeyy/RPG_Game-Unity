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

    public Interactable focus;
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
                FocusRemove();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable!=null)
                {
                    setFocus(interactable);
                }
            }
        }

    }
    void setFocus(Interactable focusNew)
    {
        if(focusNew!=focus)
        {
            if(focus!=null)
            focus.OnEnFocus();
            focus = focusNew;
            motor.FollowTarget(focusNew);
        }
        
        focusNew.OnFocus(transform);
       
    }

    void FocusRemove()
    {
        if(focus!=null)
        {
            focus.OnEnFocus();
        }
        motor.StopTarget();
        focus = null;
        
    }
}
