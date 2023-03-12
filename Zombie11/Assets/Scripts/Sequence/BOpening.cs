using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class BOpening : MonoBehaviour
{
    //시나리오 텍스트
    public Text textBox;
    //1인칭 플레이어
    public GameObject thePlayer;    

    // Start is called before the first frame update
    void Start()
    {
        //배경음 플레이
        AudioManager.instance.PlayBgm("SHAmb");

        //플레어 컨트롤러 비활성화
        thePlayer.GetComponent<FirstPersonController>().enabled = false;

        StartCoroutine(SequencePlayer());
    }

    IEnumerator SequencePlayer()
    {
        //2초동안 깜깜하고 2초후에 페인드인 효과 시작
        yield return new WaitForSeconds(2f);
        
        textBox.text = "";
        //플레어 컨트롤러 활성화
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }



}
