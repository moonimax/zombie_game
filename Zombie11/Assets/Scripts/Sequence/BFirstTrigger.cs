using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class BFirstTrigger : MonoBehaviour
{
    //캐릭터 플레이어
    public GameObject thePlayer;
    //테이블위의 화살표
    public GameObject theArrow;
    //시나리오 텍스트
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
