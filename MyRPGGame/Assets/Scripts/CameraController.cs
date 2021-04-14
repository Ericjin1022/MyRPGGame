using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;//��������Ŀ��

    public Vector3 offset;

    public float zoomSpeed=4f;//zoomSpeed�޶������ֵ������ٶ�
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    public float yawSpeed = 100f;//�޶��ӽ��ƶ����ٶ�

    private float currentZoom = 10f;
    private float currentYaw = 0f;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);//ʹ�� clamp �������������ӡ���С������仯����ֵ������һϵ�е�ֵ��

        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
    //LateUpdate �������� Update ��������֮�󱻵���
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position+Vector3.up*pitch);//��pitchƫ�����������۲���λ��
        
        transform.RotateAround(target.position,Vector3.up,currentYaw);
    
    }
}
