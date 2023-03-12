using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class BFirstTrigger : MonoBehaviour
{
    //ĳ���� �÷��̾�
    public GameObject thePlayer;
    //���̺����� ȭ��ǥ
    public GameObject theArrow;
    //�ó����� �ؽ�Ʈ
    public Text textBox;
    
    private void OnTriggerEnter(Collider other)
    {
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(SequencePlayer());
    }

    IEnumerator SequencePlayer()
    {
        textBox.text = "";
        yield return new WaitForSeconds(0.5f);

        textBox.text = "Look like a weapon on the table";
        AudioManager.instance.Play("Scene02_Line03");
        yield return new WaitForSeconds(2f);

        textBox.text = "";
        theArrow.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = false;

        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
