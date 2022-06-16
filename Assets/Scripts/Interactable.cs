using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float InteractiveRadius = 1f;
    public Transform InteractableTransform;

    private bool isFocused = false;
    private bool hasInteracted = false;

    Transform player;

    public virtual void Interact()
    {
        Debug.Log("Interact");
    }

    private void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float _distance = Vector3.Distance(player.position, InteractableTransform.position);
            if(_distance <= InteractiveRadius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnUnFocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (InteractableTransform == null) InteractableTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractableTransform.position, InteractiveRadius);
    }
}
