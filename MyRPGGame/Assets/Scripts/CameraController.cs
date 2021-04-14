using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;//相机跟随的目标

    public Vector3 offset;

    public float zoomSpeed=4f;//zoomSpeed限定鼠标滚轮调整的速度
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    public float yawSpeed = 100f;//限定视角移动的速度

    private float currentZoom = 10f;
    private float currentYaw = 0f;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);//使用 clamp 函数将不断增加、减小或随机变化的数值限制在一系列的值中

        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
    //LateUpdate 是在所有 Update 方法调用之后被调用
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position+Vector3.up*pitch);//用pitch偏移量来调整观察点的位置
        
        transform.RotateAround(target.position,Vector3.up,currentYaw);
    
    }
}
