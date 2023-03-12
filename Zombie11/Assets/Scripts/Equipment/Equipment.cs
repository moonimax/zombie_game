using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    #region Singleton
    public static Equipment instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public delegate void EquipmentDelegate(Equip oldItem, Equip newItem);
    public EquipmentDelegate equipDelegate;

    public delegate void SelectDelegate(int index);
    public SelectDelegate selectCallBack;


    public Equip[] items;

    private void Start()
    {
        items = new Equip[(int)EquipType.TypeMax];
    }

    public void EquipItem(Equip newItem)
    {
        //equip ����
        int index = (int)newItem.equipType;

        Equip oldItem = items[index];
        if(oldItem != null)
        {
            Inventory.instance.AddItem(oldItem);
        }

        items[index] = newItem;

        //Equipment�� ���� - UpdateEquipment(), OnEqiupItemChanged()
        if (equipDelegate != null)
            equipDelegate(oldItem, newItem);
    }

    public void UnEquipItem(Equip oldItem)
    {
        //equip ����
        int index = (int)oldItem.equipType;
        items[index] = null;

        //�κ��丮�� oldItem�� ����
        Inventory.instance.AddItem(oldItem);

        //Equipment�� ���� - UpdateEquipment(), OnEqiupItemChanged()
        if (equipDelegate != null)
            equipDelegate(oldItem, null);
    }

    public void SelectSlot(int index)
    {
        //EquipmentUI �� SelectSlot �޼��� ȣ��
        if(selectCallBack != null)
            selectCallBack(index);
    }
}
