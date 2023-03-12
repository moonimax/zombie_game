using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Interactive �׼� ��ũ��ũ���� �θ� Ŭ����
// DoorCellOpen, PickUpPistol : �ڽ� Ŭ����
public abstract class Interaction : MonoBehaviour
{
    //�߻� �޼ҵ�
    public abstract void DoAction();

    //�÷��̾���� �Ÿ��� �޾ƿ´�
    public float theDistance;

    //�׼� key ���� �׼� text�� �����ش�
    public GameObject actionKey;
    public GameObject actionText;
    //ũ�ν� ����� �׵θ� �κ�
    public GameObject extraCross;

    public string aText;

    //Interaction ��� ����
    public bool unIteractive = false;

    private void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        //Interaction ��� ����
        if (unIteractive)
            return;

        //PlayerCasting.distanceFromTarget : 2 ����
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
                //�浹ü ��Ȱ��
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
