using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public delegate void InventoryDelegate(int add); //선언 - 대신할 메소드와 같은 형식
    public InventoryDelegate invenDelegate;   //

    public delegate void SeletSlotDelegate(int slot);
    public SeletSlotDelegate selectCallBack;

    public List<Item> items = new List<Item>();

    public int invenSize = 16;

    public void AddItem(Item _item)
    {
        if(items.Count >= invenSize)
        {
            return;
        }

        items.Add(_item);

        //인벤토리 UI 갱신
        if(invenDelegate != null)
            invenDelegate(1);
    }

    public void RemoveItem(Item _item)
    {
        items.Remove(_item);

        //인벤토리 UI 갱신
        if (invenDelegate != null)
            invenDelegate(-1);
    }

    public bool isInventoryFull()
    {
        return (items.Count >= invenSize);
    }

    public void SelectSlot(int _index)
    {
        //인벤토리 아이템선택 갱신
        //inventoryUI.SelectSlot(_index);
        if(selectCallBack != null)
        {
            selectCallBack(_index);
        }
    }
}
