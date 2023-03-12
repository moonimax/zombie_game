using UnityEngine;

[CreateAssetMenu(fileName="New Equipment",menuName = "Equip")]
public class Equip : Item
{
    public EquipType equipType;

    public float attack;
    public float defense;

    public override void Use()
    {
        Debug.Log("�������� �����Ͽ���");
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