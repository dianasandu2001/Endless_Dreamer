using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable_Control : MonoBehaviour
{
    public static int coin_count;
    public GameObject coin_count_display;

    public GameObject player;

    public static float distance_count = 0;
    public GameObject distance_count_display;

    // Start is called before the first frame update
    void Start()
    {
        coin_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coin_count_display.GetComponent<Text>().text = "" + coin_count;

        distance_count = (player.transform.position.z + 25)/2;
        distance_count_display.GetComponent<Text>().text = "" + (int)distance_count + " m";
    }
}
