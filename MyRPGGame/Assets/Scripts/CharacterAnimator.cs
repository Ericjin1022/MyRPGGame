using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float speedPercent = agent.velocity.magnitude / agent.speed;//speed在运动过程中不变，是路程除以时间；而velocity是物体运动的实时速度，包括靠近目标点时的减速
        animator.SetFloat("SpeedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
    }
}
