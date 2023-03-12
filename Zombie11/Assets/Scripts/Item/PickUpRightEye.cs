using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRightEye : PickUpItem
{
    public GameObject rightEyePiece;
    public GameObject rightEyeUI;
    public GameObject rightEyeLight;

    public GameObject fakeWall;
    public GameObject hiddenWall;

    public GameObject fullEyeLight;

    public override void PickUp()
    {
        //아이템 획득 처리 - 인벤토리에 추가
        Inventory.instance.AddItem(item);


        //

        StartCoroutine(ShowRightEyeUI());
    }

    IEnumerator ShowRightEyeUI()
    {
        PlayerStats.instance.haveKeys[(int)KeyWord.ROOM04_RIGHTEYE] = true;

        rightEyePiece.SetActive(false);
        rightEyeLight.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        rightEyeUI.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        rightEyeUI.SetActive(false);

        //숨겨진 출구가 보이도록 한다
        fakeWall.SetActive(false);
        hiddenWall.SetActive(true);

        //퍼즐 박스 조명 온
        fullEyeLight.SetActive(true);


    }
}
