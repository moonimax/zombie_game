using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// itme PickUp �׼� ��ũ��ũ���� �θ� Ŭ����
// PickUpPistol : �ڽ� Ŭ����
public abstract class PickUpItem : MonoBehaviour
{
    //�߻� �޼ҵ�
    public abstract void PickUp();

    public Item item;

    //�÷��̾���� �Ÿ��� �޾ƿ´�
    public float theDistance;

    //�׼� key ���� �׼� text�� �����ش�
    public GameObject actionKey;
    public GameObject actionText;
    //ũ�ν� ����� �׵θ� �κ�
    public GameObject extraCross;

    private void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    private void OnMouseOver()
    {        
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
                if (!Inventory.instance.isInventoryFull())
                {
                    //�浹ü ��Ȱ��
                    this.GetComponent<BoxCollider>().enabled = false;

                    HideActionUI();

                    //interacive action
                    PickUp();
                }
                else
                {
                    Debug.Log("Inventory Full!!");
                }
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
        actionText.GetComponent<Text>().text = "Pick Up " + item.name;
    }

    private void HideActionUI()
    {
        extraCross.SetActive(false);
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }

    
}
