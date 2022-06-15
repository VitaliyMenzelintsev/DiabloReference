using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMovement : MonoBehaviour
{
    Transform _target;
    NavMeshAgent Agent;


    public void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(_target != null)
        {
            Agent.SetDestination(_target.position);
            FaceToTarget();
        }
    }

    public void MoveToPoint(Vector3 _point)
    {
        Agent.SetDestination(_point);
    }

    public void FollowToTarget(Interactable _newTarget)
    {
        Agent.stoppingDistance = _newTarget.radius * 0.8f;
        Agent.updateRotation = false;
        _target = _newTarget.transform;
    }

    public void StopFollowToTarget()
    {
        Agent.stoppingDistance = 0f;
        Agent.updateRotation = true;
        _target = null;
    }

    private void FaceToTarget() // поворот в сторону цели
    {
        Vector3 _direction = (_target.position - transform.position).normalized;
        Quaternion _lookRotation = Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 5f);
    }
}
