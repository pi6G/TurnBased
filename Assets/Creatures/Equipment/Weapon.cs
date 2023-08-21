using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string name;

    public float attackBoost;
    public float attackDifficulty;

    public float price;

    public Sprite sprite;
}
