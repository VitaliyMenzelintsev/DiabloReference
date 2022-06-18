using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMovement : MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _navMeshAgent;


    public void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(_target != null)
        {
            _navMeshAgent.SetDestination(_target.position);
            FaceToTarget();
        }
    }

    public void MoveToPoint(Vector3 _point)
    {
        _navMeshAgent.SetDestination(_point);
    }

    public void FollowToTarget(Interactable _newTarget)
    {
        _navMeshAgent.stoppingDistance = _newTarget.InteractiveRadius * 0.8f;
        _navMeshAgent.updateRotation = false;
        _target = _newTarget.InteractableTransform;
    }

    public void StopFollowToTarget()
    {
        _navMeshAgent.stoppingDistance = 0.5f;
        _navMeshAgent.updateRotation = true;
        _target = null;
    }

    private void FaceToTarget() // поворот в сторону цели
    {
        Vector3 _direction = (_target.position - transform.position).normalized;
        Quaternion _lookRotation = Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 5f);
    }
}
