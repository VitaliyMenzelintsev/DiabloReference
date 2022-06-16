using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� �� GO GameManager
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

    public bool Add(Item Item)
    {
        if (!Item.IsDefaultItem)
        {
            if(Items.Count >= Capacity)
            {
                Debug.Log("inventory full");
                return false;
            }
            Items.Add(Item);

            if(OnItemChangedCallBack != null)   // �������� ��������� � ���������
                OnItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(Item Item)
    {
        Items.Remove(Item);

        if (OnItemChangedCallBack != null)  // �������� ��������� � ���������
            OnItemChangedCallBack.Invoke();
    }
}
