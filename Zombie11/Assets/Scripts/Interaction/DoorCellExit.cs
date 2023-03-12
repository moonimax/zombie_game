using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCellExit : Interaction
{
    public SceneFader fader;
    public string loadToScene = "MainScene002";

    public GameObject theDoor;

    //1�������� 2�������� �� ����
    public override void DoAction()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        theDoor.GetComponent<Animation>().Play("Door1OpenAnim");
        yield return new WaitForSeconds(1f);

        //1���� ������
        AudioManager.instance.StopBgm();
        //�� ����
        fader.FadeTo(loadToScene);
    }
}
