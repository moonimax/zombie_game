using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class BOpening : MonoBehaviour
{
    //�ó����� �ؽ�Ʈ
    public Text textBox;
    //1��Ī �÷��̾�
    public GameObject thePlayer;    

    // Start is called before the first frame update
    void Start()
    {
        //����� �÷���
        AudioManager.instance.PlayBgm("SHAmb");

        //�÷��� ��Ʈ�ѷ� ��Ȱ��ȭ
        thePlayer.GetComponent<FirstPersonController>().enabled = false;

        StartCoroutine(SequencePlayer());
    }

    IEnumerator SequencePlayer()
    {
        //2�ʵ��� �����ϰ� 2���Ŀ� ���ε��� ȿ�� ����
        yield return new WaitForSeconds(2f);
        
        textBox.text = "";
        //�÷��� ��Ʈ�ѷ� Ȱ��ȭ
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }



}
