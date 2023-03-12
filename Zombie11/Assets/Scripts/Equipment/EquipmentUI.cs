using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EquipmentUI : MonoBehaviour
{
    private Equipment equipment;

    public GameObject equipmentUI;
    public GameObject itemInfoUI;

    public Transform equipItems;
    private EquipSlot[] itemSlots;

    private InventoryUI invenUI;

    public bool isOpenEquipUI = false;
    public bool isOpenItemInfoUI = false;

    private int selectIndex = -1;

    private void Start()
    {
        equipment = Equipment.instance;
        equipment.equipDelegate += UpdateEquipment;
        equipment.selectCallBack += SelectSlot;

        invenUI = this.GetComponent<InventoryUI>();
        itemSlots = equipItems.GetComponentsInChildren<EquipSlot>();
    }

    private void Update()
    {
        //u키를 누르면 equipmentUI가 보였다 안보였다 구현
        if (Input.GetKeyDown(KeyCode.U))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        if(isOpenEquipUI)
        {
            CloseEquipmentUI();
        }
        else
        {
            StartCoroutine(OpenEquipmentUI());
        }
    }

    IEnumerator OpenEquipmentUI()
    {   
        //InvenUI 오픈되었는지 안되었는지
        if(!invenUI.isOpenInvenUI)
        {
            invenUI.OpenInvenUI();
            yield return new WaitForSeconds(0.33f);
        }

        equipmentUI.GetComponent<Animation>().Play("EquipUIOpen");
        isOpenEquipUI = true;
    }

    public void CloseEquipmentUI()
    {
        equipmentUI.GetComponent<Animation>().Play("EquipUIClose");
        isOpenEquipUI = false;
    }

    public void CloseEquipmentUI2()
    {
        equipmentUI.GetComponent<Animation>().Play("EquipUIClose2");
    }

    public void UpdateEquipment(Equip oldItem, Equip newItem)
    {
        /*
        //모든 슬롯 초기화
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].ResetEqipSlot();
        }

        //equipment 아이템을 슬롯에 셋팅
        for (int i = 0; i < equipment.items.Length; i++)
        {
            itemSlots[i].SetEquipSlot(equipment.items[i]);
        }
        */

        int index = 0;
        if(oldItem != null)
            index = (int)oldItem.equipType;
        if(newItem != null)
            index = (int)newItem.equipType;

        itemSlots[index].ResetEqipSlot();
        itemSlots[index].SetEquipSlot(newItem);
    }

    public void SelectSlot(int index)
    {
        if(selectIndex == index)
        {
            CloseItemInfoUI();
            return;
        }

        //인벤토리창 선택 해제
        invenUI.CloseItemInfoUI();

        selectIndex = index;
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(selectIndex == i)
            {
                itemSlots[i].SetSelectImage(true);
            }
            else
            {
                itemSlots[i].SetSelectImage(false);
            }
        }

        OpenItemInfoUI();
    }

    public void DeselectSlot()
    {
        if (selectIndex == -1)
            return;

        itemSlots[selectIndex].SetSelectImage(false);
        selectIndex = -1;
    }

    public void OpenItemInfoUI()
    {
        if (!isOpenItemInfoUI)
        {
            itemInfoUI.GetComponent<Animation>().Play("ItemInfoUIOpen");
        }

        itemInfoUI.GetComponent<ItemInfoUI>().UpdateItemInfo(itemSlots[selectIndex].item);

        isOpenItemInfoUI = true;
    }

    public void CloseItemInfoUI()
    {
        if (selectIndex == -1)
            return;

        itemSlots[selectIndex].SetSelectImage(false);
        selectIndex = -1;

        itemInfoUI.GetComponent<Animation>().Play("ItemInfoUIClose");
        isOpenItemInfoUI = false;
    }

    public void UnEquipment()
    {
        equipment.UnEquipItem(itemSlots[selectIndex].item);
        CloseItemInfoUI();
    }

    public void UnEquipmentAll()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
                continue;

            equipment.UnEquipItem(itemSlots[i].item);
        }
        CloseItemInfoUI();
    }

}
