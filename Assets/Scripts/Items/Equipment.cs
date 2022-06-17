using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot EquipSlot;

    public int ArmorModifier;
    public int DamageModifier;

    public override void Use()
    {
        base.Use();
        // надеть снаряжение
        EquipmentManager.Instance.Equip(this);
        // удалить снаряжение из инвентаря
        RemoveFromInventory();
    }
}

// перечисление видов одежды
public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
