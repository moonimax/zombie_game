using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 능력치를 관리하는 클래스 : 싱글톤
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

    //탄환 관리 변수
    public int ammorCount;

    //열쇠 소지 여부
    public bool[] haveKeys;

    private void Start()
    {
        Equipment.instance.equipDelegate += OnEqiupItemChanged;

        //플레이씬 테스트를 위해 임시로 셋팅
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
