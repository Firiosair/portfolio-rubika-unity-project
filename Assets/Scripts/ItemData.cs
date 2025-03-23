using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="item", menuName="Items/New item")]

public class ItemData : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite visual;
    public GameObject prefab;
    public bool loosable = true;
    public ItemType itemType;
}

public enum ItemType
{
    Ressource,
    Equipement,
    Consumable
}