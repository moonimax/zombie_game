using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellKey : Interaction
{
    public GameObject theDoor;

    public Text textBox;

    public override void DoAction()
    {
        if (PlayerStats.instance.haveKeys[(int)KeyWord.ROOM01_DOORKEY])
        {
            //���谡 �ִ� ���
            OpenDoor();
        }
        else
        {
            //���谡 ���� ���
            StartCoroutine(LockedDoor());
        }
    }

    private void OpenDoor()
    {
        theDoor.GetComponent<Animation>().Play("Door2OpenAnim");
        AudioManager.instance.Play("CreakyDoor2");
    }

    IEnumerator LockedDoor()
    {
        //Interaction ��� ����
        unIteractive = true;
        //�浹ü Ȱ��ȭ
        this.GetComponent<BoxCollider>().enabled = true;

        textBox.text = "";
        //����� �Ҹ�
        AudioManager.instance.Play("DoorLocked");
        yield return new WaitForSeconds(1f);
                
        //Ű�� �ʿ���
        textBox.text = "I need to The Key";
        yield return new WaitForSeconds(2f);

        textBox.text = "";
        unIteractive = false;
    }
}
