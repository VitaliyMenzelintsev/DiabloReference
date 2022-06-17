using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "Name";
    public Sprite Icon = null;
    public bool IsDefaultItem = false;

    public virtual void Use()
    {
        // у разных групп предметов реализация должна быть разной

        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
    }
}
