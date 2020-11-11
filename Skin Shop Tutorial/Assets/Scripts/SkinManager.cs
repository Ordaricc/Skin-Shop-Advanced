using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance;

    public static Sprite equippedSkin { get; private set; }

    [SerializeField] private SSkinInfo[] allSkins;
    private const string skinPref = "skinPref";

    [SerializeField] private Transform skinsInShopPanelsParent;
    [SerializeField] private List<SkinInShop> skinsInShopPanels = new List<SkinInShop>();//SFD

    private Button currentlyEquippedSkinButton;

    private void Awake()
    {
        Instance = this;

        foreach (Transform s in skinsInShopPanelsParent)
        {
            if (s.TryGetComponent(out SkinInShop skinInShop))
                skinsInShopPanels.Add(skinInShop);
        }

        EquipPreviousSkin();


        SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinSprite == equippedSkin);
        currentlyEquippedSkinButton = skinEquippedPanel.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;
    }
    
    private void EquipPreviousSkin()
    {
        string lastSkinUsed = PlayerPrefs.GetString(skinPref, SSkinInfo.SkinIDs.brown.ToString());
        SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinID.ToString() == lastSkinUsed);
        EquipSkin(skinEquippedPanel);
    }

    public void EquipSkin(SkinInShop skinInfoInShop)
    {
        equippedSkin = skinInfoInShop._skinInfo._skinSprite;
        PlayerPrefs.SetString(skinPref, skinInfoInShop._skinInfo._skinID.ToString());

        if (currentlyEquippedSkinButton != null)
            currentlyEquippedSkinButton.interactable = true;

        currentlyEquippedSkinButton = skinInfoInShop.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;
    }
}