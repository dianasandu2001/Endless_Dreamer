using UnityEngine;
using UnityEngine.UI;

public class IngredientsPurchase : MonoBehaviour
{
    //Forest
    public GameObject Orchid_display;
    public GameObject Firefly_display;
    public GameObject Glowstone_display;

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
        Orchid_display.GetComponent<Text>().text = "" + GameManager.manager.orchids;
        Firefly_display.GetComponent<Text>().text = "" + GameManager.manager.fireflies;
        Glowstone_display.GetComponent<Text>().text = "" + GameManager.manager.glowStones;

        //Map 2

        //Map 3

        //Map 4
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
