using UnityEngine;

//[CreateAssetMenu(menuName = "Costs")]
public class Costs : MonoBehaviour
{
    //Character costs 
    public float ClaireCost; // Coins
    public float AjCost; // Coins
    public float GrannyCost; // Gems
    public float MichelleCost; // Gems

    //character costs text
    public string ClaireCostText; // Coins
    public string AjCostText; // Coins
    public string GrannyCostText; // Gems
    public string MichelleCostText; // Gems

    //map costs
    public float desertCost; // coins
    public float cloudsCost; //
    public float dungeonCost; //

    //ingredients
    public float ingredientCoinCost; // Coins
    public float ingredientGemCost; // Gems
    public float dustCost; // Gems

    //potions
    public float healthPotionCost; // Gems
    public float scorePotionCost; // Gems
    public float debuffPotionCost; // Gems

    //Coins
    public float Coins100Cost; // Gems
    public float Coins500Cost; // Gems
    public float Coins1000Cost; // Gems

    //Amounts
    public float IngredientAmount; // amount of ingredients purchased at one time 
    public float DustAmount;
}
