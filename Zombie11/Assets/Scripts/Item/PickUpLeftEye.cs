using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLeftEye : PickUpItem
{
    public GameObject leftEyePiece;
    public GameObject leftEyeUI;
    public GameObject leftEyeLight;

    public override void PickUp()
    {
        //아이템 획득 처리 - 인벤토리에 추가
        Inventory.instance.AddItem(item);

        //


        StartCoroutine(ShowLeftEyeUI());
    }

    IEnumerator ShowLeftEyeUI()
    {
        PlayerStats.instance.haveKeys[(int)KeyWord.ROOM02_LEFTEYE] = true;
        leftEyePiece.SetActive(false);
        leftEyeLight.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        leftEyeUI.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        leftEyeUI.SetActive(false);
    }
}
