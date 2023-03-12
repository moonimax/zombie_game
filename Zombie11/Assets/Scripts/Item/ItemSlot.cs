using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [HideInInspector]
    public Item item;

    private int slotIndex;

    public GameObject iconImage;
    public GameObject selectImage;

    public void SetItemSlot(Item _item, int _index)
    {
        item = _item;
        slotIndex = _index;

        iconImage.SetActive(true);
        iconImage.GetComponent<Image>().sprite = item.iconImage;
    }

    public void ResetItemSlot()
    {
        item = null;

        iconImage.SetActive(false);
        iconImage.GetComponent<Image>().sprite = null;

        selectImage.SetActive(false);
    }

    public void SelectSlot()
    {
        if(item == null)
            return;

        Inventory.instance.SelectSlot(slotIndex);
    }

    public void SetSelectImage(bool isSelect)
    {
        selectImage.SetActive(isSelect);
    }

}
