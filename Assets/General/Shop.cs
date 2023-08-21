using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Player player;

    [SerializeField] private Button upgradeHat;
    [SerializeField] private Button upgradeSuit;
    [SerializeField] private Button upgradeWeapon;


    [SerializeField] private TMP_Text hatPrice;
    [SerializeField] private TMP_Text suitPrice;
    [SerializeField] private TMP_Text weaponPrice;

    public Hat[] hats;
    public Suit[] suits;
    public Weapon[] weapons;

    private int currentHat;
    private int currentSuit;
    private int currentWeapon;

    public static float money;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        currentHat = 0;
        currentSuit = 0;
        currentWeapon = 0;
    }

    public void onShopEnter()
    {
        RefreshPriceAvailable();
        RefreshAvailable();
    }

    public void RefreshPriceAvailable()
    {
        if (hats[currentHat + 1].price > money)
            upgradeHat.interactable = false;
        else
            upgradeHat.interactable = true;

        if (weapons[currentWeapon + 1].price > money)
            upgradeWeapon.interactable = false;
        else
            upgradeWeapon.interactable = true;

        if (suits[currentSuit + 1].price > money)
            upgradeSuit.interactable = false;
        else
            upgradeSuit.interactable = true;

        FindObjectOfType<UIStateManager>().UpdateCoins();
    }

    public void RefreshAvailable()
    {
        if (hats[currentHat + 1] != null)
            hatPrice.text = hats[currentHat + 1].price.ToString();
        else
        {
            hatPrice.text = "Unavailable";
            upgradeHat.interactable = false;
        }

        if (suits[currentSuit + 1] != null)
            suitPrice.text = suits[currentSuit + 1].price.ToString();
        else
        {
            suitPrice.text = "Unavailable";
            upgradeSuit.interactable = false;
        }

        if (weapons[currentWeapon + 1] != null)
            weaponPrice.text = weapons[currentWeapon + 1].price.ToString();
        else
        {
            suitPrice.text = "Unavailable";
            upgradeWeapon.interactable = false;
        }
    }

    public void OnUpgradeHat()
    {
        ++currentHat;
        money -= hats[currentHat].price;

        player.hat = hats[currentHat];
        player.RefreshSprites();

        RefreshPriceAvailable();
        RefreshAvailable();
    }

    public void OnUpgradeSuit()
    {
        ++currentSuit;
        money -= suits[currentSuit].price;

        player.suit = suits[currentSuit];
        player.RefreshSprites();

        RefreshPriceAvailable();
        RefreshAvailable();
    }

    public void OnUpgradeWeapon()
    {
        ++currentWeapon;
        money -= weapons[currentWeapon].price;

        player.weapon = weapons[currentWeapon];
        player.RefreshSprites();

        RefreshPriceAvailable();
        RefreshAvailable();
    }
}
