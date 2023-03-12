using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpAmmor : PickUpItem
{
    public int giveAmmor = 7;

    public override void PickUp()
    {
        //아이템 획득 처리 - 인벤토리에 추가
        Inventory.instance.AddItem(item);

        //

        //탄환 7개 지급
        PlayerStats.instance.AddAmmor(giveAmmor);

        Destroy(gameObject);
    }
}
