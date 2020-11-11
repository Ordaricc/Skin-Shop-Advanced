using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinInShop : MonoBehaviour
{
    [SerializeField] private SSkinInfo skinInfo;
    public SSkinInfo _skinInfo { get { return skinInfo; } }

    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Image skinImage;

    [SerializeField] private bool isSkinUnlocked;//SFD
    [SerializeField] private bool isFreeSkin;

    private void Awake()
    {
        skinImage.sprite = skinInfo._skinSprite;

        if (isFreeSkin)
        {
            if (PlayerMoney.Instance.TryRemoveMoney(0))
            {
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
            }
        }

        IsSkinUnlocked();
    }

    private void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
        else
        {
            buttonText.text = "Buy: " + skinInfo._skinPrice;
        }
    }

    public void OnButtonPress()
    {
        if (isSkinUnlocked)
        {
            //equip
            SkinManager.Instance.EquipSkin(this);
        }
        else
        {
            //buy
            if (PlayerMoney.Instance.TryRemoveMoney(skinInfo._skinPrice))
            {
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                IsSkinUnlocked();
            }
        }
    }
}