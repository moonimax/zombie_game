using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾��� �ɷ�ġ�� �����ϴ� Ŭ���� : �̱���
public class PlayerStats : CharacterStats
{
    public static PlayerStats instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int sceneNum;
    

    public WeaponType weaponType = WeaponType.NONE;

    //źȯ ���� ����
    public int ammorCount;

    //���� ���� ����
    public bool[] haveKeys;

    private void Start()
    {
        Equipment.instance.equipDelegate += OnEqiupItemChanged;

        //�÷��̾� �׽�Ʈ�� ���� �ӽ÷� ����
        newStartGameData();
    }

    public void InitPlayerStats(PlayData pData)
    {
        InitStats();

        if (pData != null)
        {
            sceneNum = pData.sceneNum;
            health = pData.health;
            ammorCount = pData.ammorCount;
            weaponType = pData.weaponType;
        }
        else
        {
            sceneNum = 0;
            ammorCount = 0;
            weaponType = WeaponType.NONE;
        }

        haveKeys = new bool[(int)KeyWord.MAX_KEY];
    }

    public void newStartGameData()
    {
        InitStats();

        sceneNum = 0;
        ammorCount = 0;
        weaponType = WeaponType.NONE;

        for(int i = 0; i < haveKeys.Length; i++)
        {
            haveKeys[i] = false;
        }
    }

    public void AddAmmor(int amount)
    {
        ammorCount += amount;
    }

    public bool UseAmmor(int amount)
    {
        if(ammorCount < amount)
        {
            return false;
        }

        ammorCount -= amount;
        return true;
    }

}

public enum WeaponType
{
    NONE,
    PISTOL,
}

public enum KeyWord
{
    ROOM01_DOORKEY,
    ROOM02_LEFTEYE,
    ROOM04_RIGHTEYE,
    MAX_KEY
}
