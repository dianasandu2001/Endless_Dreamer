using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientsPurchase : MonoBehaviour
{
    public Costs costs;

    public Text coin_display;
    public Text gem_display;
    //Forest
    public Text Orchid_display;
    public Text Firefly_display;
    public Text Glowstone_display;

    public TMP_Text Orchid_coin;
    public TMP_Text Firefly_coin;
    public TMP_Text Glowstone_coin;

    public TMP_Text Orchid_gem;
    public TMP_Text Firefly_gem;
    public TMP_Text Glowstone_gem;

    //Map 2
    //public GameObject ing1;
    //public GameObject ing2;
    //public GameObject ing3;

    //Map3
    //public GameObject ing4;
    //public GameObject ing5;
    //public GameObject ing6;

    //Map 4
    //public GameObject ing7;
    //public GameObject ing8;
    //public GameObject ing9;

    //Tabs
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    void Start()
    {
        //Forest
        Orchid_display.text = "" + GameManager.manager.orchids;
        Firefly_display.text = "" + GameManager.manager.fireflies;
        Glowstone_display.text = "" + GameManager.manager.glowStones;

        Orchid_coin.text = "" + (costs.IngredientAmount * costs.ingredientCoinCost);
        Firefly_coin.text = "" + (costs.IngredientAmount * costs.ingredientCoinCost);
        Glowstone_coin.text = "" + (costs.IngredientAmount * costs.ingredientCoinCost);

        Orchid_gem.text = "" + (costs.IngredientAmount * costs.ingredientGemCost);
        Firefly_gem.text = "" + (costs.IngredientAmount * costs.ingredientGemCost);
        Glowstone_gem.text = "" + (costs.IngredientAmount * costs.ingredientGemCost);
        //Map 2

        //Map 3

        //Map 4
    }

    public void ForestTab()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }
    public void Map2Tab()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }
    public void Map3Tab()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(true);
        Panel4.SetActive(false);
    }
    public void Map4Tab()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(true);
    }

    public void BuyOrchidCoins()
    {
        if (GameManager.manager.coins >= (costs.IngredientAmount * costs.ingredientCoinCost))
        {
            GameManager.manager.orchids += costs.IngredientAmount;
            GameManager.manager.coins -= (costs.IngredientAmount * costs.ingredientCoinCost);

            Orchid_display.text = "" + GameManager.manager.orchids;
            coin_display.text = "" + GameManager.manager.coins;

            GameManager.manager.Save();
        }
    }
    public void BuyFireflyCoins()
    {
        if (GameManager.manager.coins >= (costs.IngredientAmount * costs.ingredientCoinCost))
        {
            GameManager.manager.fireflies += costs.IngredientAmount;
            GameManager.manager.coins -= (costs.IngredientAmount * costs.ingredientCoinCost);

            Firefly_display.text = "" + GameManager.manager.fireflies;
            coin_display.text = "" + GameManager.manager.coins;

            GameManager.manager.Save();
        }
    }
    public void BuyGlowstoneCoins()
    {
        if (GameManager.manager.coins >= (costs.IngredientAmount * costs.ingredientCoinCost))
        {
            GameManager.manager.glowStones += costs.IngredientAmount;
            GameManager.manager.coins -= (costs.IngredientAmount * costs.ingredientCoinCost);

            Glowstone_display.text = "" + GameManager.manager.glowStones;
            coin_display.text = "" + GameManager.manager.coins;

            GameManager.manager.Save();
        }
    }
    public void BuyOrchidGem()
    {
        if (GameManager.manager.gems >= (costs.IngredientAmount * costs.ingredientGemCost))
        {
            GameManager.manager.orchids += costs.IngredientAmount;
            GameManager.manager.gems -= (costs.IngredientAmount * costs.ingredientGemCost);

            Orchid_display.text = "" + GameManager.manager.orchids;
            gem_display.text = "" + GameManager.manager.gems;

            GameManager.manager.Save();
        }
    }
    public void BuyFireflyGem()
    {
        if (GameManager.manager.gems >= (costs.IngredientAmount * costs.ingredientGemCost))
        {
            GameManager.manager.fireflies += costs.IngredientAmount;
            GameManager.manager.gems -= (costs.IngredientAmount * costs.ingredientGemCost);

            Firefly_display.text = "" + GameManager.manager.fireflies;
            gem_display.text = "" + GameManager.manager.gems;

            GameManager.manager.Save();
        }
    }
    public void BuyGlowStoneGem()
    {
        if (GameManager.manager.gems >= (costs.IngredientAmount * costs.ingredientGemCost))
        {
            GameManager.manager.glowStones += costs.IngredientAmount;
            GameManager.manager.gems -= (costs.IngredientAmount * costs.ingredientGemCost);

            Glowstone_display.text = "" + GameManager.manager.glowStones;
            gem_display.text = "" + GameManager.manager.gems;

            GameManager.manager.Save();
        }
    }
}
