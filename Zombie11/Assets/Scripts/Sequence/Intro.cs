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
        //����� �÷���
        AudioManager.instance.PlayBgm("OpeningSequence");

        StartCoroutine(SequencePlayer());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //�� ��ŵ
            StopAllCoroutines();
            fader.FadeTo(loadToScene);
        }
    }

    IEnumerator SequencePlayer()
    {
        //ī�޶� �ִϸ��̼� ����
        mainCamera.GetComponent<Animation>().Play("IntroAnim");
        yield return new WaitForSeconds(6f);
        //��Ʈ�� Ÿ��Ʋ �ؽ�Ʈ ��Ȱ��
        introTitleUI .SetActive(false);
        yield return new WaitForSeconds(35.5f);
        //���θ� ���� ��
        theShedLight.SetActive(true);
        yield return new WaitForSeconds(9.5f);
        //���θ� ���� ����
        theShedLight.SetActive(false);
        yield return new WaitForSeconds(2f);
        //���ξ����� �̵�
        fader.FadeTo(loadToScene);
    }
}
