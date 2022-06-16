using UnityEngine;

// ����� �������� �� ����������� �������� ������� � ���������
public class ItemPickUp : Interactable
{
    public Item Item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picked up " + Item.name);
        bool _wasPickedUp = Inventory.Instance.Add(Item);

        if(_wasPickedUp)
            Destroy(gameObject);
    }
}
