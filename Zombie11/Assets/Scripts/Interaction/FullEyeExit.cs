using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullEyeExit : Interaction
{
    public GameObject emptyEye;
    public GameObject fullEyePiece;

    public GameObject hiddenExit;
    public GameObject hiddenExitTrigger;

    public Text textBox;

    public override void DoAction()
    {   
        if(PlayerStats.instance.haveKeys[(int)KeyWord.ROOM02_LEFTEYE] && PlayerStats.instance.haveKeys[(int)KeyWord.ROOM04_RIGHTEYE])
        {
            //������ ��� ����� ���
            StartCoroutine(OpenHiddenExit());
        }
        else
        {
            //������ ��� ����� ������ ���
            StartCoroutine(LockedHiddenExit());
        }
    }

    IEnumerator OpenHiddenExit()
    {
        //fulleye
        emptyEye.SetActive(false);
        fullEyePiece.SetActive(true);

        //�ⱸ ������ �ִϸ��̼�
        hiddenExit.GetComponent<Animation>().Play("HiddenExitAnim");

        yield return new WaitForSeconds(1f);

        //�ⱸ Ʈ���� Ȱ��ȭ
        hiddenExitTrigger.SetActive(true);
    }

    IEnumerator LockedHiddenExit()
    {
        //Interaction ��� ����
        unIteractive = true;

        //������ ��� �浹ü �� Ȱ��ȭ
        this.GetComponent<BoxCollider>().enabled = true;
                
        //���� ������ �ʿ���
        textBox.text = "More Pictures";
        yield return new WaitForSeconds(2f);

        //
        textBox.text = "";
        unIteractive = false;
    }
}
