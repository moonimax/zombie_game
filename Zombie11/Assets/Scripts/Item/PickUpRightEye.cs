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
        //������ ȹ�� ó�� - �κ��丮�� �߰�
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

        //������ �ⱸ�� ���̵��� �Ѵ�
        fakeWall.SetActive(false);
        hiddenWall.SetActive(true);

        //���� �ڽ� ���� ��
        fullEyeLight.SetActive(true);


    }
}
