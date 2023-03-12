using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat attack;
    public Stat defense;

    public float startAttack = 5;
    public float startDefense = 10;

    [HideInInspector]
    public float health;
    public float maxHealth = 100f;

    public bool isDeath = false;

    //캐릭터 스탯 초기화
    public void InitStats()
    {
        attack.SetBaseValue(startAttack);
        defense.SetBaseValue(startDefense);

        health = maxHealth;
    }

    public void OnEqiupItemChanged(Equip oldItem, Equip newItem)
    {
        //oldItem : 장비에서 빼는 아이템
        if (oldItem != null)
        {
            attack.RemoveValue(oldItem.attack);
            defense.RemoveValue(oldItem.defense);
        }

        //newItem : 장비에 넣는 아이템
        if (newItem != null)
        {
            attack.AddValue(newItem.attack);
            defense.AddValue(newItem.defense);
        }
    }
}
