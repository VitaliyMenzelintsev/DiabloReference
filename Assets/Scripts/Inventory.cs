using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Скрипт отвечает за обработку инвентаря игрока. Висит на GO GameManager
public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Item> Items = new List<Item>();

    public void Add(Item Item)
    {
        if (!Item.IsDefaultItem)
        {
            Items.Add(Item);
        }
    }

    public void Remove(Item Item)
    {
        Items.Remove(Item);
    }

}
