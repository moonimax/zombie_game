using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    new public string name;
    public string description;

    public int manaCost;
    public int attack;
    public int health;

    public Sprite artImage;
}
