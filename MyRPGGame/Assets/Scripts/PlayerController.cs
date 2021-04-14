using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public Interactable focus;

    Camera cam;
    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,100,movementMask))
            {
                //Move our player to what we hit
                motor.MovetoPoint(hit.point);
                //Stop focusing any objects
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();//�Ҽ���������������Ƿ���interactable�ű�
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }
    //1.���ñ��ű��Ľ��㡣2.motor�������Զ�Ѱ·���յ�
    void SetFocus(Interactable newFocus)
    {
        if(newFocus!=focus)
        {
            if(focus!=null)
                focus.OnDefocused();
            
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }
    //1.ɢ����2.
    void RemoveFocus()
    {
        if(focus!=null)
            focus.OnDefocused();
        motor.StopFollowingTarget();
    }
}
