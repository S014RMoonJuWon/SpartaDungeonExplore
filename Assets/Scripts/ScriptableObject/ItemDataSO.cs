using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Usable,
    Stuff
}

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "New Item", order = 0)]
public class ItemDataSO : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public GameObject dropPrefab;
}
