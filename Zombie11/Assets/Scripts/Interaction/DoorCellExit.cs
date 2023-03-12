using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCellExit : Interaction
{
    public SceneFader fader;
    public string loadToScene = "MainScene002";

    public GameObject theDoor;

    //1¹ø¾À¿¡¼­ 2¹ø¾ÀÀ¸·Î ¾À º¯°æ
    public override void DoAction()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        theDoor.GetComponent<Animation>().Play("Door1OpenAnim");
        yield return new WaitForSeconds(1f);

        //1¹ø¾À ¸¶¹«¸®
        AudioManager.instance.StopBgm();
        //¾À º¯°æ
        fader.FadeTo(loadToScene);
    }
}
