using UnityEngine;
using UnityEngine.AI;

public class AnimatorController : MonoBehaviour
{
    const float LocomotionAnimationSmoothTime = 0.1f;

    private Animator _characterAnimator;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _characterAnimator = GetComponent<Animator>(); // если аниматор висит не на родительском обьекте, а на дочерней графике нужно использовать GetComponentInChildren
        _navMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        float _speedPercent = _navMeshAgent.velocity.magnitude / _characterAnimator.speed;
        _characterAnimator.SetFloat("speedPercent", _speedPercent, LocomotionAnimationSmoothTime, Time.deltaTime);
    }

    public void Running()
    {

    }

    public void Idle()
    {

    }
}
