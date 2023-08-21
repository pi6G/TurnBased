using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hat", menuName = "Hat")]
public class Hat : ScriptableObject
{
    public string name;

    public float skillBoost;
    public float skillDifficulty;

    public float price;

    public Sprite sprite;
}
