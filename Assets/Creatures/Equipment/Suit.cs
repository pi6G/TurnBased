using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Suit", menuName = "Suit")]
public class Suit : ScriptableObject
{
    public string name;

    public float defenseBoost;
    public float healingDifficulty;

    public float price;

    public Sprite sprite;
}
