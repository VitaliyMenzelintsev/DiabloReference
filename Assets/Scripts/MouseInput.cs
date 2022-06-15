using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private Vector3 _clickPosition;
    PlayerMovement PlayerMovement;

    private void Start()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            LockatePosition();
        }
        else
        {
            PlayerMovement.StayInPosition();
        }
    }

    private void LockatePosition()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out _hit))
        {
            _clickPosition = new Vector3(_hit.point.x, _hit.point.y, _hit.point.z);
        }
        PlayerMovement.LookDirection(_clickPosition);
    }
}
