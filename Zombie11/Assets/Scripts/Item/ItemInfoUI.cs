using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour
{
    public Text nameText;
    public Text desriptionText;

    public GameObject useButton;
    public GameObject sellButton;
    public GameObject equipButton;
    public GameObject unEquipButton;

    public void UpdateItemInfo(Item selectItem)
    {
        //��ư �ʱ�ȭ
        ResetButtons();

        //������ ����
        nameText.text = selectItem.name;
        desriptionText.text = selectItem.description;

        //��ư Ȱ��ȭ
        if(selectItem.itemType == ItemType.Equip)
        {
            equipButton.SetActive(true);
            sellButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(true);
            sellButton.SetActive(true);
        }
    }

    public void UpdateItemInfo(Equip selectItem)
    {
        //��ư �ʱ�ȭ
        ResetButtons();

        //������ ����
        nameText.text = selectItem.name;
        desriptionText.text = selectItem.description;

        //��ư Ȱ��ȭ
        unEquipButton.SetActive(true);
    }

    private void ResetButtons()
    {
        useButton.SetActive(false);
        sellButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);

    }
}
