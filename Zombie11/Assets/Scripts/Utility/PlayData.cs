using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//파일에 저장할 게임 플레이 데이터(이진화 BinaryFormat)
[System.Serializable]
public class PlayData
{
    public int sceneNum;
    public float health;
    public int ammorCount;
    public WeaponType weaponType;

    public PlayData()
    {
        //저장할 데이터 값 셋팅
        sceneNum = PlayerStats.instance.sceneNum;
        health = PlayerStats.instance.health;
        ammorCount = PlayerStats.instance.ammorCount;
        weaponType = PlayerStats.instance.weaponType;
        //.....
    }
}
