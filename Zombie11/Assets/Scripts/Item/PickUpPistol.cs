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
        //������ ȹ�� ó�� - �κ��丮�� �߰�
        Inventory.instance.AddItem(item);

        //

        //interacive action
        fakePistol.SetActive(false);
        theArrow.SetActive(false);
                
        realPistol.SetActive(true);
        ammorUI.SetActive(true);

        //źȯ �ڽ��� ���� Ȱ��ȭ
        ammorLight.SetActive(true);

        PlayerStats.instance.weaponType = WeaponType.PISTOL;

        jumpScareTrigger.SetActive(true);
    }
}
