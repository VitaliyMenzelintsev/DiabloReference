using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private Equipment[] _currentEquipment;
    private Inventory _inventory;

    public delegate void OnEquipmentChanged(Equipment _newItem, Equipment _oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start()
    {
        _inventory = Inventory.Instance;

        // _numSlots сохраняет количество слотов снаряжения 
        int _numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        _currentEquipment = new Equipment[_numSlots];
    }

    public void Equip(Equipment _newItem) // оснащение снаряжением
    {
        int _slotIndex = (int)_newItem.EquipSlot;

        Equipment _oldItem = null;

        if(_currentEquipment[_slotIndex] != null) // удаление снаряжения 
        {
            _oldItem = _currentEquipment[_slotIndex];
            _inventory.Add(_oldItem);             // возвращение в инвентарь снимаемого предмета
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(_newItem, _oldItem);
        }

        _currentEquipment[_slotIndex] = _newItem;
    }

    public void UnEqiup(int _slotIndex)
    {
        if(_currentEquipment[_slotIndex] != null)
        {
            Equipment _oldItem = _currentEquipment[_slotIndex];
            _inventory.Add(_oldItem);

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, _oldItem);
            }

            _currentEquipment[_slotIndex] = null;
        }
    }

    public void UnEqiupAll()
    {
        for (int i = 0; i < _currentEquipment.Length; i++)
        {
            UnEqiup(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnEqiupAll();
    }
}
