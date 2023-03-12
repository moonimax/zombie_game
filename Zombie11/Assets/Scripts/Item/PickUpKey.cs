using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : PickUpItem
{
    public GameObject theKey;

    public override void PickUp()
    {
        //아이템 획득 처리 - 인벤토리에 추가
        Inventory.instance.AddItem(item);

        //

        PlayerStats.instance.haveKeys[(int)KeyWord.ROOM01_DOORKEY] = true;

        theKey.SetActive(false);
    }
}
