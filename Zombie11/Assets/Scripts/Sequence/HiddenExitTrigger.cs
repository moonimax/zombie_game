using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenExitTrigger : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainMenu";

    private void OnTriggerEnter(Collider other)
    {
        //¾À Á¾·á Ã³¸®
        AudioManager.instance.StopBgm();

        fader.FadeTo(loadToScene);
    }
}
