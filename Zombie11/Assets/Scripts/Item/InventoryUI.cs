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
        inven.invenDelegate = UpdateInventory; //����� �޼ҵ� ��������Ʈ�� ���
        inven.selectCallBack = SelectSlot;

        equipmentUI = this.GetComponent<EquipmentUI>();

        //itemSlots = items.GetComponentsInChildren<ItemSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        //iŰ�� ������ �κ��丮 UI ���̰�, iŰ�� ������ �κ��丮 UI �Ⱥ��̰� ����
        //�κ��丮 UI�� ���̸� Ŀ�� ���̰� ȭ�� ����
        if (Input.GetKeyDown(KeyCode.I))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if(isOpenInvenUI) //�κ�â�� ������ 
        {
            StartCoroutine(CloseInvenUI());
        }
        else //�Ⱥ��϶�
        {
            OpenInvenUI();
        }
    }

    public void OpenInvenUI()
    {
        //�÷��� ��Ʈ�ѷ� ��Ȱ��ȭ
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        thePlayer.GetComponentInChildren<FirePistol>().enabled = false;

        //���콺 Ŀ��
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
                
        invenUI.GetComponent<Animation>().Play("InvenUIOpen");
        isOpenInvenUI = true;
    }

    IEnumerator CloseInvenUI()
    {
        //�������� ���õǾ� ����â�� ���̰� �ִ� ����
        if(isOpenItemInfoUI || equipmentUI.isOpenEquipUI)
        {
            //�κ��丮 ������ ����â
            if (isOpenItemInfoUI)
            {
                CloseItemInfoUI();
            }
            //��� ����â
            if (equipmentUI.isOpenEquipUI)
            {
                equipmentUI.CloseEquipmentUI();
            }
            //��� ���� ������ ����â
            if (equipmentUI.isOpenItemInfoUI)
            {
                equipmentUI.CloseItemInfoUI();
            }
            yield return new WaitForSeconds(0.33f);
        }

        itemInfoUI.GetComponent<Animation>().Play("ItemInfoUIClose2");
        equipmentUI.CloseEquipmentUI2();

        //�÷��� ��Ʈ�ѷ� Ȱ��ȭ
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
        thePlayer.GetComponentInChildren<FirePistol>().enabled = true;

        //���콺 Ŀ��
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        invenUI.GetComponent<Animation>().Play("InvenUIClose");
        isOpenInvenUI = false;
    }

    //�κ��丮 ����Ʈ�� �ִ� �����۵��� UI�� �� ���Ը��� ����
    public void UpdateInventory(int add)
    {
        //�����տ� ����
        if(add == 1)//�������߰� 
        {
            GameObject slot = Instantiate(itemSlotPrefab) as GameObject;
            slot.transform.SetParent(items.transform, false);
            ItemSlot itemSlot = slot.GetComponent<ItemSlot>();
            itemSlots.Add(itemSlot);
        }
        else if(add == -1) //������ ����
        {
            itemSlots.RemoveAt(0);
            Destroy(items.transform.GetChild(0).gameObject);
        }

        //��� ���� ����
        for (int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].ResetItemSlot();
        }

        //�� ���Կ� ������ ����
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

        //�������â ���� ����
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

        //���� ����
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
        Debug.Log(itemSlots[selectIndex].item.name + " �������� ����Ͽ���");
        itemSlots[selectIndex].item.Use();
        inven.RemoveItem(itemSlots[selectIndex].item);

        CloseItemInfoUI();
    }

    public void SellItem()
    {
        Debug.Log(itemSlots[selectIndex].item.name + " �������� �����Ͽ���");
        inven.RemoveItem(itemSlots[selectIndex].item);

        CloseItemInfoUI();
    }

}
