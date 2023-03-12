using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    [HideInInspector]
    public Equip item;

    private int slotIndex;

    public GameObject iconImage;
    public GameObject selectImage;

    public void SetEquipSlot(Equip _item)
    {
        if (_item == null)
            return;

        item = _item;
        slotIndex = (int)_item.equipType;

        iconImage.SetActive(true);
        iconImage.GetComponent<Image>().sprite = item.iconImage;
    }

    public void ResetEqipSlot()
    {
        item = null;

        iconImage.SetActive(false);
        iconImage.GetComponent<Image>().sprite = null;

        selectImage.SetActive(false);
    }

    public void SelectSlot()
    {
        if (item == null)
            return;

        Equipment.instance.SelectSlot(slotIndex);
    }

    public void SetSelectImage(bool isSelect)
    {
        selectImage.SetActive(isSelect);
    }
}
