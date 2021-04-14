using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;//Target to follow;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();//如果有焦点则每时每刻更新面向的位置
        }
    }
    
    public void MovetoPoint(Vector3 point)//左键执行的函数
    {
        agent.SetDestination(point);
    }
    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform;
    }
    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        
        target = null;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;//向量
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);//根据时间deltatime每次插值一点点,范围是前两个参数

    }
}
