using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    //10초후에 Main Menu씬으로 자동 이동하도록 구현
    //아무키나 누르면 Main Menu씬으로 자동 이동하도록 구현

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

        //3초후 키가 유효하게
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
