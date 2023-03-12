using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainScene001"; //������ �� �̸�
    public string loadToMenu = "MainMenu"; //������ �� �̸�

    private void Start()
    {   
        //Ŀ���� ���� �����ش�, Ŀ���� �����ش�
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
