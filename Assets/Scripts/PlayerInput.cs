using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public LayerMask MovementMask;
    public Interactable Focus;
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
            FocusOnTarget();
        }
    }

    private void LockatePosition()  // ������� ��������� �����, ������� ������� ��� � ����� ����� ���������
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out RaycastHit _hit, 100, MovementMask))
        {
            PlayerMovement.MoveToPoint(_hit.point);
            RemoveFocus();
        }
    }

    private void FocusOnTarget()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit _hit, 100))
        {
            Interactable interactable = _hit.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                SetFocus(interactable);
            }
        }
    }

    private void SetFocus(Interactable _focusTarget)
    {
        Focus = _focusTarget;
        PlayerMovement.FollowToTarget(_focusTarget);
    }

    private void RemoveFocus()
    {
        Focus = null;
        PlayerMovement.StopFollowToTarget();
    }
}
