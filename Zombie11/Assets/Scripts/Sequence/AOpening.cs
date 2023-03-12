using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class AOpening : MonoBehaviour
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

        //3�� ���� �ó����� �ؽ�Ʈ ���̰� ���ش�
        textBox.text = "...Where am I?";
        AudioManager.instance.Play("Scene02_Line01");
        yield return new WaitForSeconds(3f);

        //3�� ���� �ó����� �ؽ�Ʈ ���̰� ���ش�
        textBox.text = "I need to get out of here";
        AudioManager.instance.Play("Scene02_Line02");
        yield return new WaitForSeconds(3f);

        textBox.text = "";

        //�÷��� ��Ʈ�ѷ� Ȱ��ȭ
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
