using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryUI : MonoBehaviour
{
    private Inventory inven;

    public GameObject invenUI;
    public GameObject itemInfoUI;

    public Transform thePlayer;

    public GameObject itemSlotPrefab;
    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    public Transform items;

    private int selectIndex = -1;

    private EquipmentUI equipmentUI;

    public bool isOpenInvenUI = false;
    public bool isOpenItemInfoUI = false;

    // Start is called before the first frame update
    void Start()
    {
        inven = Inventory.instance;
        inven.invenDelegate = UpdateInventory; //대신할 메소드 델리게이트에 등록
        inven.selectCallBack = SelectSlot;

        equipmentUI = this.GetComponent<EquipmentUI>();

        //itemSlots = items.GetComponentsInChildren<ItemSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        //i키를 누르면 인벤토리 UI 보이고, i키를 누르면 인벤토리 UI 안보이게 구현
        //인벤토리 UI가 보이면 커서 보이고 화면 고정
        if (Input.GetKeyDown(KeyCode.I))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if(isOpenInvenUI) //인벤창이 보여서 
        {
            StartCoroutine(CloseInvenUI());
        }
        else //안보일때
        {
            OpenInvenUI();
        }
    }

    public void OpenInvenUI()
    {
        //플레어 컨트롤러 비활성화
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        thePlayer.GetComponentInChildren<FirePistol>().enabled = false;

        //마우스 커서
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
                
        invenUI.GetComponent<Animation>().Play("InvenUIOpen");
        isOpenInvenUI = true;
    }

    IEnumerator CloseInvenUI()
    {
        //아이템이 선택되어 정보창이 보이고 있는 상태
        if(isOpenItemInfoUI || equipmentUI.isOpenEquipUI)
        {
            //인벤토리 아이템 정보창
            if (isOpenItemInfoUI)
            {
                CloseItemInfoUI();
            }
            //장비 장착창
            if (equipmentUI.isOpenEquipUI)
            {
                equipmentUI.CloseEquipmentUI();
            }
            //장비 장착 아이템 정보창
            if (equipmentUI.isOpenItemInfoUI)
            {
                equipmentUI.CloseItemInfoUI();
            }
            yield return new WaitForSeconds(0.33f);
        }

        itemInfoUI.GetComponent<Animation>().Play("ItemInfoUIClose2");
        equipmentUI.CloseEquipmentUI2();

        //플레어 컨트롤러 활성화
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
        thePlayer.GetComponentInChildren<FirePistol>().enabled = true;

        //마우스 커서
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        invenUI.GetComponent<Animation>().Play("InvenUIClose");
        isOpenInvenUI = false;
    }

    //인벤토리 리스트에 있는 아이템들을 UI의 각 슬롯마다 셋팅
    public void UpdateInventory(int add)
    {
        //프리팹에 구현
        if(add == 1)//아이템추가 
        {
            GameObject slot = Instantiate(itemSlotPrefab) as GameObject;
            slot.transform.SetParent(items.transform, false);
            ItemSlot itemSlot = slot.GetComponent<ItemSlot>();
            itemSlots.Add(itemSlot);
        }
        else if(add == -1) //아이템 제거
        {
            itemSlots.RemoveAt(0);
            Destroy(items.transform.GetChild(0).gameObject);
        }

        //모든 슬롯 비우기
        for (int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].ResetItemSlot();
        }

        //각 슬롯에 아이템 셋팅
        for (int i = 0; i < inven.items.Count; i++)
        {
            itemSlots[i].SetItemSlot(inven.items[i], i);
        }
    }

    public void SelectSlot(int _index)
    {
        if(selectIndex == _index)
        {
            CloseItemInfoUI();
            return;
        }

        //장비장착창 선택 해제
        equipmentUI.CloseItemInfoUI();

        //
        selectIndex = _index;

        for (int i = 0; i < itemSlots.Count; i++)
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

    private void OpenItemInfoUI()
    {
        if(!isOpenItemInfoUI)
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

        //선택 해제
        if (selectIndex < itemSlots.Count)
        {
            itemSlots[selectIndex].SetSelectImage(false);
        }
        selectIndex = -1;

        itemInfoUI.GetComponent<Animation>().Play("ItemInfoUIClose");
        isOpenItemInfoUI = false;
    }

    public void UseItem()
    {
        Debug.Log(itemSlots[selectIndex].item.name + " 아이템을 사용하였다");
        itemSlots[selectIndex].item.Use();
        inven.RemoveItem(itemSlots[selectIndex].item);

        CloseItemInfoUI();
    }

    public void SellItem()
    {
        Debug.Log(itemSlots[selectIndex].item.name + " 아이템을 제거하였다");
        inven.RemoveItem(itemSlots[selectIndex].item);

        CloseItemInfoUI();
    }

}
