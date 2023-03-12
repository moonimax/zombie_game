using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ͽ� ������ ���� �÷��� ������(����ȭ BinaryFormat)
[System.Serializable]
public class PlayData
{
    public int sceneNum;
    public float health;
    public int ammorCount;
    public WeaponType weaponType;

    public PlayData()
    {
        //������ ������ �� ����
        sceneNum = PlayerStats.instance.sceneNum;
        health = PlayerStats.instance.health;
        ammorCount = PlayerStats.instance.ammorCount;
        weaponType = PlayerStats.instance.weaponType;
        //.....
    }
}
