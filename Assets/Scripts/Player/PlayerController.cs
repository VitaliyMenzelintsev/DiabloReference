using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public LayerMask MovementMask;
    public Interactable Focus;

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;            // проверка, нет ли между курсором и поверхностью UI

        if (Input.GetMouseButton(0))
            LockatePosition();

        if (Input.GetMouseButton(1))
            FocusOnTarget();
    }

    private void LockatePosition()  
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out RaycastHit _hit, 100, MovementMask))
        {
            _playerMovement.MoveToPoint(_hit.point);
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
        if(_focusTarget != Focus)
        {
            if (Focus != null) Focus.OnUnFocused();
            
            Focus = _focusTarget;
            _playerMovement.FollowToTarget(_focusTarget);
        }
        _focusTarget.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if(Focus != null) Focus.OnUnFocused();

        Focus = null;
        _playerMovement.StopFollowToTarget();
    }
}
