using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string price;
    public string description;
    //public Sprite icon;
   //public GameObject ItemPrefab;

    //[Header("Equip")]
    //public GameObject equipPrefab;
}