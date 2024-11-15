using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable_Control : MonoBehaviour
{
    public static int coin_count;
    public Text coin_count_display;

    public static int gem_count;
    public Text gem_count_display;

    public GameObject player;

    public static float distance_count;
    public Text distance_count_display;

    public static float score_count;
    public Text score_count_display;

    public float potion_score_multiplier;
    public float player_score_multiplier;

    // Start is called before the first frame update
    void Start()
    {
        coin_count = 0;
        gem_count = 0;
        distance_count = 0;
        score_count = 0;
        potion_score_multiplier = 1;
        player_score_multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        coin_count_display.text = "" + coin_count;
        gem_count_display.text = "" + gem_count;
        
        distance_count = (player.transform.position.z + 25)/2;
        distance_count_display.text = "" + (int)distance_count + " m";

        score_count = distance_count * potion_score_multiplier * player_score_multiplier;
        score_count_display.text = "" + (int)score_count;
    }
}
