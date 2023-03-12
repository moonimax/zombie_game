using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainScene001";

    private bool isCreditShow = false;
    public GameObject menu;
    public GameObject credit;

    public GameObject optionUI;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public AudioMixer audioMixer;

    public GameObject loadGame;
    
    private void Start()
    {
        InitGameData();

        AudioManager.instance.PlayBgm("MenuMusic");
        if (PlayerStats.instance.sceneNum > 0)
        {
            loadGame.SetActive(true);
        }
    }

    //���ӿ� �ʿ��� ������ �ʱⰪ ����
    private void InitGameData()
    {
        //�ɼ� ������ �ҷ��ͼ� ���ӿ� �����Ѵ�
        LoadOptions();

        //����� ������ �ҷ�����
        PlayData pData = SaveLoad.LoadData();
        PlayerStats.instance.InitPlayerStats(pData);
        //....
    }

    private void Update()
    {
        if (isCreditShow)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideCredits();
            }
            return;
        }
    }

    public void NewGame()
    {
        PlayerStats.instance.newStartGameData();

        AudioManager.instance.StopBgm();
        AudioManager.instance.Play("ButtonHit");

        fader.FadeTo(loadToScene);
    }

    public void LoadGame()
    {
        AudioManager.instance.StopBgm();
        AudioManager.instance.Play("ButtonHit");

        fader.FadeTo(PlayerStats.instance.sceneNum);
    }

    public void Options()
    {
        menu.SetActive(false);
        optionUI.SetActive(true);
    }

    public void HideOptions()
    {
        //�ɼǺ��� ������ �����Ѵ�
        SaveOptions();

        menu.SetActive(true);
        optionUI.SetActive(false);
    }

    public void SetBgmVolume(float value)
    {
        //PlayerPrefs.SetFloat("BgmVolume", value);

        audioMixer.SetFloat("BgmVolume", value);
    }

    public void SetSfxVolume(float value)
    {
        //PlayerPrefs.SetFloat("SfxVolume", value);

        audioMixer.SetFloat("SfxVolume", value);
    }

    public void Credits()
    {
        isCreditShow = true;
        menu.SetActive(false);
        credit.SetActive(true);
    }

    private void HideCredits()
    {
        isCreditShow = false;
        menu.SetActive(true);
        credit.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!!!");
        Application.Quit();
    }

    //�ɼ��� ���� ������ �����Ѵ�
    private void SaveOptions()
    {
        PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
        PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
    }

    //�ɼ��� ���� ������ �����´�
    private void LoadOptions()
    {
        //����� ���� ���尪 ����
        float bgm = PlayerPrefs.GetFloat("BgmVolume", 0f);
        SetBgmVolume(bgm);
        bgmSlider.value = bgm;

        //ȿ���� ���� ���尪 ����
        float sfx = PlayerPrefs.GetFloat("SfxVolume", 0f);
        SetSfxVolume(sfx);
        sfxSlider.value = sfx;

        //��Ÿ..
    }
}
