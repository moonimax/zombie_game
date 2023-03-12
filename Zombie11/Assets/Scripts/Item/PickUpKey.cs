using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : PickUpItem
{
    public GameObject theKey;

    public override void PickUp()
    {
        //������ ȹ�� ó�� - �κ��丮�� �߰�
        Inventory.instance.AddItem(item);

        //

        PlayerStats.instance.haveKeys[(int)KeyWord.ROOM01_DOORKEY] = true;

        theKey.SetActive(false);
    }
}
