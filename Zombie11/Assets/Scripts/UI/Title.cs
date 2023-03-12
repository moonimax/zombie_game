using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    //10���Ŀ� Main Menu������ �ڵ� �̵��ϵ��� ����
    //�ƹ�Ű�� ������ Main Menu������ �ڵ� �̵��ϵ��� ����

    public SceneFader fader;
    public string loadToScene = "MainMenu";

    public float delayTimer = 10f;
    private float countdown = 0f;

    private void Update()
    {
        if (countdown > delayTimer)
        {
            GotoMenu();
            return;
        }
        countdown += Time.deltaTime;

        //3���� Ű�� ��ȿ�ϰ�
        if(Input.anyKeyDown && countdown > 3f)
        {
            GotoMenu();
        }
    }

    private void GotoMenu()
    {
        fader.FadeTo(loadToScene);
    }


}
