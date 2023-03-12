using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Interactive 액션 스크립크들의 부모 클래스
// DoorCellOpen, PickUpPistol : 자식 클래스
public abstract class Interaction : MonoBehaviour
{
    //추상 메소드
    public abstract void DoAction();

    //플레이어와의 거리를 받아온다
    public float theDistance;

    //액션 key 값과 액션 text를 보여준다
    public GameObject actionKey;
    public GameObject actionText;
    //크로스 헤어의 테두리 부분
    public GameObject extraCross;

    public string aText;

    //Interaction 기능 제한
    public bool unIteractive = false;

    private void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        //Interaction 기능 제한
        if (unIteractive)
            return;

        //PlayerCasting.distanceFromTarget : 2 이하
        if (theDistance < 2)
        {
            ShowActionUI();
        }
        else
        {
            HideActionUI();
        }

        if (Input.GetButtonDown("Action"))
        {
            if (theDistance < 2)
            {
                //충돌체 비활성
                this.GetComponent<BoxCollider>().enabled = false;

                HideActionUI();

                //interacive action
                DoAction();
            }
        }
    }

    private void OnMouseExit()
    {
        HideActionUI();
    }

    private void ShowActionUI()
    {
        extraCross.SetActive(true);
        actionKey.SetActive(true);
        actionText.SetActive(true);
        actionText.GetComponent<Text>().text = aText;
    }

    private void HideActionUI()
    {
        extraCross.SetActive(false);
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }

    
}
