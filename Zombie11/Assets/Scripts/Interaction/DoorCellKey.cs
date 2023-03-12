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
            //열쇠가 있는 경우
            OpenDoor();
        }
        else
        {
            //열쇠가 없는 경우
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
        //Interaction 기능 제한
        unIteractive = true;
        //충돌체 활성화
        this.GetComponent<BoxCollider>().enabled = true;

        textBox.text = "";
        //문잠긴 소리
        AudioManager.instance.Play("DoorLocked");
        yield return new WaitForSeconds(1f);
                
        //키가 필요해
        textBox.text = "I need to The Key";
        yield return new WaitForSeconds(2f);

        textBox.text = "";
        unIteractive = false;
    }
}
