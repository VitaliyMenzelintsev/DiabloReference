using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "Name";
    public Sprite Icon = null;
    public bool IsDefaultItem = false;
}
