using UnityEngine;

public class PlayerController : MonoBehaviour
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

    private void LockatePosition()  // сделать отдельный метод, который пускает луч и выдаёт точку попадания
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
        if(_focusTarget != Focus)
        {
            if (Focus != null) Focus.OnUnFocused();
            
            Focus = _focusTarget;
            PlayerMovement.FollowToTarget(_focusTarget);
        }
        _focusTarget.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if(Focus != null) Focus.OnUnFocused();

        Focus = null;
        PlayerMovement.StopFollowToTarget();
    }
}
