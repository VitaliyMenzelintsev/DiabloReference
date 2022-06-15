using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseInput))]

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5f;
    public CharacterController CharacterController;
    PlayerAnimator PlayerAnimator;

    public void Start()
    {
        PlayerAnimator = GetComponent<PlayerAnimator>();
    }

    public void LookDirection(Vector3 _position)
    {
        if (Vector3.Distance(transform.position, _position) > 2) // чтобы персонаж перестал двигаться
        {
            Quaternion _rotation = Quaternion.LookRotation(_position - transform.position);
            _rotation.x = 0f; // можно было заблочить в инспекторе
            _rotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, Time.deltaTime * 5);
            MoveToPosition();
        }

    }

    public void MoveToPosition()
    {
        CharacterController.SimpleMove(transform.forward * _speed);
        PlayerAnimator.Running();
    }

    public void StayInPosition()
    {
        PlayerAnimator.Idle();
    }
}
