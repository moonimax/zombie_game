using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : PickUpItem
{
    public GameObject fakePistol;    
    public GameObject theArrow;

    public GameObject realPistol;
    public GameObject ammorUI;

    public GameObject ammorLight;

    public GameObject jumpScareTrigger;

    public override void PickUp()
    {
        //아이템 획득 처리 - 인벤토리에 추가
        Inventory.instance.AddItem(item);

        //

        //interacive action
        fakePistol.SetActive(false);
        theArrow.SetActive(false);
                
        realPistol.SetActive(true);
        ammorUI.SetActive(true);

        //탄환 박스의 조명 활성화
        ammorLight.SetActive(true);

        PlayerStats.instance.weaponType = WeaponType.PISTOL;

        jumpScareTrigger.SetActive(true);
    }
}
