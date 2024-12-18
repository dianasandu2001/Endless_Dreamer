using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class UpgradesScript : MonoBehaviour
{
    public Text coin_display;
    public Text gem_display;

    //button text of universal upgrades
    public TMP_Text speedPowerButton;
    public TMP_Text shieldPowerButton;
    public TMP_Text visionDebuffButton;
    public TMP_Text trippingButton;
    public TMP_Text coinMultiplierButton;

    // levels of universal ungrades
    public TMP_Text speedPowerLevel;
    public TMP_Text shieldPowerLevel;
    public TMP_Text visionDebuffLevel;
    public TMP_Text trippingLevel;
    public TMP_Text coinMultiplierLevel;

    //images for universal upgrades
    public GameObject[] speedPowerImage;
    public GameObject[] shieldPowerImage;
    public GameObject[] visionDebuffImage;
    public GameObject[] trippingImage;
    public GameObject[] coinMultiplierImage;

    public string[] upgradeCosts;
    public GameObject[] overlay;

    //character side
    public TMP_Text characterLevel;
    public Image XPBar;

    public GameObject spawn_uprades;
    private GameObject player_upgrades;
    private Animator animator_upgrades;
    public TMP_Text charName;
    public string[] charNames;

    void Start()
    {
        coin_display.text = "" + GameManager.manager.coins;
        gem_display.text = "" + GameManager.manager.gems;

        //updaring upgrade images
        UpdateUpgradeProgress(speedPowerImage, GameManager.manager.speedPowerUpgrade);
        UpdateUpgradeProgress(shieldPowerImage, GameManager.manager.shieldPowerUpgrade);
        UpdateUpgradeProgress(visionDebuffImage, GameManager.manager.visionDebuffUpgrade);
        UpdateUpgradeProgress(trippingImage, GameManager.manager.trippingUpgrade);
        UpdateUpgradeProgress(coinMultiplierImage, GameManager.manager.coinMultiplierUpgrade);


        //updating upgrade level and cost
        UpdateLevelAndCosts(speedPowerLevel, speedPowerButton, upgradeCosts, GameManager.manager.speedPowerUpgrade, 5, overlay, 0);
        UpdateLevelAndCosts(shieldPowerLevel, shieldPowerButton, upgradeCosts, GameManager.manager.shieldPowerUpgrade, 5, overlay, 1);
        UpdateLevelAndCosts(visionDebuffLevel, visionDebuffButton, upgradeCosts, GameManager.manager.visionDebuffUpgrade, 5, overlay, 3);
        UpdateLevelAndCosts(trippingLevel, trippingButton, upgradeCosts, GameManager.manager.trippingUpgrade, 5, overlay, 2);
        UpdateLevelAndCosts(coinMultiplierLevel, coinMultiplierButton, upgradeCosts, GameManager.manager.coinMultiplierUpgrade, 5, overlay, 4);
        
        //Character
            // levels and XP bar
        characterLevel.text = "" + GameManager.manager.level[GameManager.manager.currentCharacter];
        XPBar.fillAmount = GameManager.manager.currentLevelXP[GameManager.manager.currentCharacter] / GameManager.manager.levelRequirements[GameManager.manager.level[GameManager.manager.currentCharacter]];
            // char model
        charName.text = charNames[GameManager.manager.currentCharacter];
        player_upgrades = Instantiate(GameManager.manager.characters[GameManager.manager.currentCharacter], spawn_uprades.transform);
        SetLayerRecursively(player_upgrades, 5);
        player_upgrades.GetComponent<Player_Move>().enabled = false;
        Destroy(player_upgrades.GetComponent<Rigidbody>()); //destroy rigid body so it doesnt fall
        animator_upgrades = player_upgrades.GetComponent<Animator>();
        animator_upgrades.SetBool("Menu", true);
    }
    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null) return;

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (child == null) continue;
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
    void Update()
    {

    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ToShopButton()
    {
        SceneManager.LoadScene("Shop");
    }
    public void SpeedPowerUpgrade()
    {
        if(GameManager.manager.speedPowerUpgrade < 4)
        {
            if (GameManager.manager.coins >= GameManager.manager.upgradeCosts[GameManager.manager.speedPowerUpgrade])
            {
                GameManager.manager.coins -= GameManager.manager.upgradeCosts[GameManager.manager.speedPowerUpgrade];
                GameManager.manager.speedPowerUpgrade += 1;
                AddUpgrade(GameManager.manager.speedTime, 1f);
            }
        }
        else if(GameManager.manager.speedPowerUpgrade == 4)
        {
            if (GameManager.manager.gems >= GameManager.manager.upgradeCosts[GameManager.manager.speedPowerUpgrade])
            {
                GameManager.manager.gems -= GameManager.manager.upgradeCosts[GameManager.manager.speedPowerUpgrade];
                GameManager.manager.speedPowerUpgrade += 1;
                AddUpgrade(GameManager.manager.speedTime, 1f);
            }
        }
        UpdateLevelAndCosts(speedPowerLevel, speedPowerButton, upgradeCosts, GameManager.manager.speedPowerUpgrade, 5, overlay, 0);
        UpdateUpgradeProgress(speedPowerImage, GameManager.manager.speedPowerUpgrade);
        GameManager.manager.Save();
        coin_display.text = "" + GameManager.manager.coins;
        gem_display.text = "" + GameManager.manager.gems;
    }
    public void ShieldPowerUpgrade()
    {
        if (GameManager.manager.shieldPowerUpgrade < 4)
        {
            if (GameManager.manager.coins >= GameManager.manager.upgradeCosts[GameManager.manager.shieldPowerUpgrade])
            {
                GameManager.manager.coins -= GameManager.manager.upgradeCosts[GameManager.manager.shieldPowerUpgrade];
                GameManager.manager.shieldPowerUpgrade += 1;
                AddUpgrade(GameManager.manager.bubbleTime, 1f);
            }
        }
        else if (GameManager.manager.shieldPowerUpgrade == 4)
        {
            if (GameManager.manager.gems >= GameManager.manager.upgradeCosts[GameManager.manager.shieldPowerUpgrade])
            {
                GameManager.manager.gems -= GameManager.manager.upgradeCosts[GameManager.manager.shieldPowerUpgrade];
                GameManager.manager.shieldPowerUpgrade += 1;
                AddUpgrade(GameManager.manager.bubbleTime, 1f);
            }
        }
        UpdateLevelAndCosts(shieldPowerLevel, shieldPowerButton, upgradeCosts, GameManager.manager.shieldPowerUpgrade, 5, overlay, 1);
        UpdateUpgradeProgress(shieldPowerImage, GameManager.manager.shieldPowerUpgrade);
        GameManager.manager.Save();
        coin_display.text = "" + GameManager.manager.coins;
        gem_display.text = "" + GameManager.manager.gems;
    }
    public void TrippingUpgrade()
    {
        if (GameManager.manager.trippingUpgrade < 4)
        {
            if (GameManager.manager.coins >= GameManager.manager.upgradeCosts[GameManager.manager.trippingUpgrade])
            {
                GameManager.manager.coins -= GameManager.manager.upgradeCosts[GameManager.manager.trippingUpgrade];
                GameManager.manager.trippingUpgrade += 1;
                SubtractUpgrade(GameManager.manager.trippedTime, 0.5f);
            }
        }
        else if (GameManager.manager.trippingUpgrade == 4)
        {
            if (GameManager.manager.gems >= GameManager.manager.upgradeCosts[GameManager.manager.trippingUpgrade])
            {
                GameManager.manager.gems -= GameManager.manager.upgradeCosts[GameManager.manager.trippingUpgrade];
                GameManager.manager.trippingUpgrade += 1;
                SubtractUpgrade(GameManager.manager.trippedTime, 0.5f);
            }
        }
        UpdateLevelAndCosts(trippingLevel, trippingButton, upgradeCosts, GameManager.manager.trippingUpgrade, 5, overlay, 2);
        UpdateUpgradeProgress(trippingImage, GameManager.manager.trippingUpgrade);
        GameManager.manager.Save();
        coin_display.text = "" + GameManager.manager.coins;
        gem_display.text = "" + GameManager.manager.gems;
    }
    public void VisionDebuffUpgrade()
    {
        if (GameManager.manager.visionDebuffUpgrade < 4)
        {
            if (GameManager.manager.coins >= GameManager.manager.upgradeCosts[GameManager.manager.visionDebuffUpgrade])
            {
                GameManager.manager.coins -= GameManager.manager.upgradeCosts[GameManager.manager.visionDebuffUpgrade];
                GameManager.manager.visionDebuffUpgrade += 1;
                SubtractUpgrade(GameManager.manager.debuffTime, 0.5f);
            }
        }
        else if (GameManager.manager.visionDebuffUpgrade == 4)
        {
            if (GameManager.manager.gems >= GameManager.manager.upgradeCosts[GameManager.manager.visionDebuffUpgrade])
            {
                GameManager.manager.gems -= GameManager.manager.upgradeCosts[GameManager.manager.visionDebuffUpgrade];
                GameManager.manager.visionDebuffUpgrade += 1;
                SubtractUpgrade(GameManager.manager.debuffTime, 1f);
            }
        }
        UpdateLevelAndCosts(visionDebuffLevel, visionDebuffButton, upgradeCosts, GameManager.manager.visionDebuffUpgrade, 5, overlay, 3);
        UpdateUpgradeProgress(visionDebuffImage, GameManager.manager.visionDebuffUpgrade);
        GameManager.manager.Save();
        coin_display.text = "" + GameManager.manager.coins;
        gem_display.text = "" + GameManager.manager.gems;
    }
    public void CoinMultiplierUpgrade()
    {
        if (GameManager.manager.coinMultiplierUpgrade < 4)
        {
            if (GameManager.manager.coins >= GameManager.manager.upgradeCosts[GameManager.manager.coinMultiplierUpgrade])
            {
                GameManager.manager.coins -= GameManager.manager.upgradeCosts[GameManager.manager.coinMultiplierUpgrade];
                GameManager.manager.coinMultiplierUpgrade += 1;
                SubtractUpgrade(GameManager.manager.trippedTime, 0.5f);
            }
        }
        else if (GameManager.manager.coinMultiplierUpgrade == 4)
        {
            if (GameManager.manager.gems >= GameManager.manager.upgradeCosts[GameManager.manager.coinMultiplierUpgrade])
            {
                GameManager.manager.gems -= GameManager.manager.upgradeCosts[GameManager.manager.coinMultiplierUpgrade];
                GameManager.manager.coinMultiplierUpgrade += 1;
                AddUpgrade(GameManager.manager.coinMultiplier, 0.2f);
            }
        }
        UpdateLevelAndCosts(coinMultiplierLevel, coinMultiplierButton, upgradeCosts, GameManager.manager.coinMultiplierUpgrade, 5, overlay, 4);
        UpdateUpgradeProgress(coinMultiplierImage, GameManager.manager.coinMultiplierUpgrade);
        GameManager.manager.Save();
        coin_display.text = "" + GameManager.manager.coins;
        gem_display.text = "" + GameManager.manager.gems;
    }
    public void ShowRewardsLevels(GameObject settingsPanel)
    {
        if (settingsPanel.activeSelf == false)
        {
            settingsPanel.SetActive(true);
        }
        else
        {
            settingsPanel.SetActive(false);
        }
    }
    public void HoverOnUpgrades(GameObject settingsPanel)
    {
        settingsPanel.SetActive(true);
    }
    public void HoverOffUpgrades(GameObject settingsPanel)
    {
        settingsPanel.SetActive(false);
    }

    void UpdateUpgradeProgress(GameObject[] list, int power)
    {
        for (int i = 1; i < list.Length + 1; i++)
        {
            if (i <= power)
            {
                list[i - 1].SetActive(true);
            }
        }
    }

    void UpdateLevelAndCosts(TMP_Text TMP_level, TMP_Text TMP_button, string[] list, int val, int max, GameObject[] overlay, int overlayVal)
    {
        if(val == max)
        {
            TMP_button.text = "Upgrade Complete";
            TMP_level.text = "" + max;
            overlay[overlayVal].SetActive(true);
        }
        else
        {
            TMP_button.text = list[val];
            TMP_level.text = "" + val;
        }
    }

    void AddUpgrade(float[] list, float val)
    {
        for(int i = 0; i < list.Length ; i++)
        {
            list[i] += val;
        }
    }
    void SubtractUpgrade(float[] list, float val)
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i] -= val;
        }
    }
}
