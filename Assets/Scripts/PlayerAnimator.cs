using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    const float LocomotionAnimationSmoothTime = 0.1f;

    Animator CharacterAnimator;
    NavMeshAgent NavMeshAgent;

    private void Start()
    {
        CharacterAnimator = GetComponent<Animator>(); // если аниматор висит не на родительском обьекте, а на дочерней графике нужно использовать GetComponentInChildren
        NavMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        float _speedPercent = NavMeshAgent.velocity.magnitude / CharacterAnimator.speed;
        CharacterAnimator.SetFloat("speedPercent", _speedPercent, LocomotionAnimationSmoothTime, Time.deltaTime);
    }

    public void Running()
    {

    }

    public void Idle()
    {

    }
}
