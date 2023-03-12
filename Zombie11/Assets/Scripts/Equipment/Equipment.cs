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
        //equip 저장
        int index = (int)newItem.equipType;

        Equip oldItem = items[index];
        if(oldItem != null)
        {
            Inventory.instance.AddItem(oldItem);
        }

        items[index] = newItem;

        //Equipment를 갱신 - UpdateEquipment(), OnEqiupItemChanged()
        if (equipDelegate != null)
            equipDelegate(oldItem, newItem);
    }

    public void UnEquipItem(Equip oldItem)
    {
        //equip 제거
        int index = (int)oldItem.equipType;
        items[index] = null;

        //인벤토리에 oldItem을 저장
        Inventory.instance.AddItem(oldItem);

        //Equipment를 갱신 - UpdateEquipment(), OnEqiupItemChanged()
        if (equipDelegate != null)
            equipDelegate(oldItem, null);
    }

    public void SelectSlot(int index)
    {
        //EquipmentUI 의 SelectSlot 메서드 호출
        if(selectCallBack != null)
            selectCallBack(index);
    }
}
