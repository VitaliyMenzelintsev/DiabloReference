using UnityEngine;


// класс отвечает за способность предмета браться в инвентарь
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
        Destroy(gameObject);
    }
}
