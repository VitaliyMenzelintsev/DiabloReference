using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class MouseInput : MonoBehaviour
{
    private Vector3 _clickPosition;
    PlayerController PlayerController;

    private void Start()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            LockatePosition();
        }
    }

    private void LockatePosition()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out _hit))
        {
            _clickPosition = new Vector3(_hit.point.x, _hit.point.y, _hit.point.z);
            Debug.Log(_clickPosition);
        }
        PlayerController.LookDirection(_clickPosition);
    }
}
