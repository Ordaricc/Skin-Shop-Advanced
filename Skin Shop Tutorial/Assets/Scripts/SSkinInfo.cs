using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName ="New Skin", menuName ="Create New Skin")]
public class SSkinInfo : ScriptableObject
{
    public enum SkinIDs { brown, red, green }

    [SerializeField] private SkinIDs skinID;
    public SkinIDs _skinID { get { return skinID; } }

    [SerializeField] private Sprite skinSprite;
    public Sprite _skinSprite { get { return skinSprite; } }

    [SerializeField] private int skinPrice;
    public int _skinPrice { get { return skinPrice; } }
}