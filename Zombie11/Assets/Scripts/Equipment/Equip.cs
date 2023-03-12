using UnityEngine;

[CreateAssetMenu(fileName="New Equipment",menuName = "Equip")]
public class Equip : Item
{
    public EquipType equipType;

    public float attack;
    public float defense;

    public override void Use()
    {
        Debug.Log("아이템을 장착하였다");
        Equipment.instance.EquipItem(this);
    }
}

public enum EquipType
{
    Head,
    Weapon,
    Shield,
    TypeMax,
}