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
        //버튼 초기화
        ResetButtons();

        //아이템 정보
        nameText.text = selectItem.name;
        desriptionText.text = selectItem.description;

        //버튼 활성화
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
        //버튼 초기화
        ResetButtons();

        //아이템 정보
        nameText.text = selectItem.name;
        desriptionText.text = selectItem.description;

        //버튼 활성화
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
