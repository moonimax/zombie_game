using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainScene001"; //변경할 씬 이름
    public string loadToMenu = "MainMenu"; //변경할 씬 이름

    private void Start()
    {   
        //커서의 락을 없애준다, 커서를 보여준다
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        fader.FadeTo(loadToScene);
    }

    public void Menu()
    {
        fader.FadeTo(loadToMenu);
    }
}
