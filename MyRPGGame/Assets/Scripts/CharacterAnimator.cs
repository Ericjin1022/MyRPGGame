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
        
        float speedPercent = agent.velocity.magnitude / agent.speed;//speed���˶������в��䣬��·�̳���ʱ�䣻��velocity�������˶���ʵʱ�ٶȣ���������Ŀ���ʱ�ļ���
        animator.SetFloat("SpeedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
    }
}
