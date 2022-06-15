using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 5f;
    public CharacterController Controller;

    public void LookDirection(Vector3 _position)
    {
        if (Vector3.Distance(transform.position, _position) > 1) // чтобы персонаж перестал двигаться
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
        Controller.SimpleMove(transform.forward * _speed);
    }
}
