using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform ItemsParent;
    public GameObject ObjectInventoryUI;

    private Inventory _inventory;

    private InventorySlot[] _slots;

    private void Start()
    {
        _inventory = Inventory.Instance;
        _inventory.OnItemChangedCallBack += UpdateUI;    // вызов метода и подписка на событие

        _slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory")) // вкл/выкл инвентарь
        {
            ObjectInventoryUI.SetActive(!ObjectInventoryUI.activeSelf);
        }
    }

    private void UpdateUI()
    {
       for (int i = 0; i < _slots.Length; i++)
        {
            if( i < _inventory.Items.Count)
            {
                _slots[i].AddItem(_inventory.Items[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
