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
            //퍼즐을 모두 모았을 경우
            StartCoroutine(OpenHiddenExit());
        }
        else
        {
            //퍼즐을 모두 모우지 못했을 경우
            StartCoroutine(LockedHiddenExit());
        }
    }

    IEnumerator OpenHiddenExit()
    {
        //fulleye
        emptyEye.SetActive(false);
        fullEyePiece.SetActive(true);

        //출구 열리는 애니메이션
        hiddenExit.GetComponent<Animation>().Play("HiddenExitAnim");

        yield return new WaitForSeconds(1f);

        //출구 트리거 활성화
        hiddenExitTrigger.SetActive(true);
    }

    IEnumerator LockedHiddenExit()
    {
        //Interaction 기능 제한
        unIteractive = true;

        //실패할 경우 충돌체 재 활성화
        this.GetComponent<BoxCollider>().enabled = true;
                
        //퍼즐 조각이 필요해
        textBox.text = "More Pictures";
        yield return new WaitForSeconds(2f);

        //
        textBox.text = "";
        unIteractive = false;
    }
}
