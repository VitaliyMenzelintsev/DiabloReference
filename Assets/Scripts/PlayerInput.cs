using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _clickPosition;
    public LayerMask MovementMask;
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
        if (Input.GetMouseButton(1))
        {
            LockatePosition();
        }
    }

    private void LockatePosition()  // сделать отдельный метод, который пускает луч и выдаёт точку попадания
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out _hit, 100, MovementMask))
        {
            _clickPosition = _hit.point;
            PlayerMovement.MoveToPoint(_clickPosition);
        }
    }

    private void FocusOnTarget()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, 100))
        {
            _clickPosition = _hit.point;
        }
    }
}
