using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainMenu";

    public GameObject puausUI;

    public GameObject thePlayer;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        puausUI.SetActive(!puausUI.activeSelf);

        if(puausUI.activeSelf)
        {
            Time.timeScale = 0f;

            //�÷��� ��Ʈ�ѷ� ��Ȱ��ȭ
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            //���콺 Ŀ��
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        } else
        {
            Time.timeScale = 1f;

            //�÷��� ��Ʈ�ѷ� Ȱ��ȭ
            thePlayer.GetComponent<FirstPersonController>().enabled = true;

            //���콺 Ŀ��
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        fader.FadeTo(loadToScene);
    }
}
