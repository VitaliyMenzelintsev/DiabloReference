using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float InteractiveRadius = 1f;
    public Transform InteractableTransform;

    private bool _isFocused = false;
    private bool _hasInteracted = false;

    private Transform _player;

    public virtual void Interact()
    {
        Debug.Log("Interact");
    }

    private void Update()
    {
        if (_isFocused && !_hasInteracted)
        {
            float _distance = Vector3.Distance(_player.position, InteractableTransform.position);
            if(_distance <= InteractiveRadius)
            {
                Interact();
                _hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform _playerTransform)
    {
        _isFocused = true;
        _player = _playerTransform;
        _hasInteracted = false;
    }

    public void OnUnFocused()
    {
        _isFocused = false;
        _player = null;
        _hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (InteractableTransform == null) InteractableTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractableTransform.position, InteractiveRadius);
    }
}
