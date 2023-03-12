using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Item")]
public class Item : ScriptableObject
{
    new public string name;
    public string description;

    public Sprite iconImage;

    public ItemType itemType;

    public virtual void Use()
    {
        //아이템 사용
    }
}

public enum ItemType
{
    Equip,
    Potion,
    Puzzle,
}
