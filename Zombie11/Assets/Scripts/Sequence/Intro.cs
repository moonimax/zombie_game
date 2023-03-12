using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainScene001";

    public Transform mainCamera;
    public GameObject introTitleUI;
    public GameObject theShedLight;

    // Start is called before the first frame update
    void Start()
    {
        //배경음 플레이
        AudioManager.instance.PlayBgm("OpeningSequence");

        StartCoroutine(SequencePlayer());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //씬 스킵
            StopAllCoroutines();
            fader.FadeTo(loadToScene);
        }
    }

    IEnumerator SequencePlayer()
    {
        //카메라 애니메이션 시작
        mainCamera.GetComponent<Animation>().Play("IntroAnim");
        yield return new WaitForSeconds(6f);
        //인트로 타이틀 텍스트 비활성
        introTitleUI .SetActive(false);
        yield return new WaitForSeconds(35.5f);
        //오두막 조명 온
        theShedLight.SetActive(true);
        yield return new WaitForSeconds(9.5f);
        //오두막 조명 오프
        theShedLight.SetActive(false);
        yield return new WaitForSeconds(2f);
        //메인씬으로 이동
        fader.FadeTo(loadToScene);
    }
}
