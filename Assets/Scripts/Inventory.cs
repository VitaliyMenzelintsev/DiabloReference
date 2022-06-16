using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Висит на GO GameManager
public class Inventory : MonoBehaviour
{   // !!!
    #region Singleton

    public static Inventory Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("More than 1 inventory");
            return;
        }
        Instance = this;
    }

    #endregion                                         
    
    // !!!
    public delegate void OnItemChanged(); 
    public OnItemChanged OnItemChangedCallBack;

    public int Capacity = 20;
    public List<Item> Items = new List<Item>();

    public bool Add(Item _item)
    {
        if (!_item.IsDefaultItem)
        {
            if(Items.Count >= Capacity)
            {
                Debug.Log("inventory full");
                return false;
            }
            Items.Add(_item);

            if(OnItemChangedCallBack != null)   // внесение изменений в инвентарь
                OnItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(Item _item)
    {
        Items.Remove(_item);

        if (OnItemChangedCallBack != null)  // внесение изменений в инвентарь
            OnItemChangedCallBack.Invoke();
    }
}
