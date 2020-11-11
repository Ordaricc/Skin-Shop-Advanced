using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney Instance;

    [SerializeField] private int playerMoney;//SFD

    private const string prefMoney = "prefMoney";

    private void Awake()
    {
        Instance = this;

        playerMoney = PlayerPrefs.GetInt(prefMoney);
    }

    public bool TryRemoveMoney(int moneyToRemove)
    {
        if (playerMoney >= moneyToRemove)
        {
            playerMoney -= moneyToRemove;
            PlayerPrefs.SetInt(prefMoney, playerMoney);
            return true;
        }
        else
        {
            return false;
        }
    }
}