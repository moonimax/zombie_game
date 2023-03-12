using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenExitTrigger : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainMenu";

    private void OnTriggerEnter(Collider other)
    {
        //�� ���� ó��
        AudioManager.instance.StopBgm();

        fader.FadeTo(loadToScene);
    }
}
