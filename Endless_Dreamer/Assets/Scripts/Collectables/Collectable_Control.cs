using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable_Control : MonoBehaviour
{
    public static int coin_count;
    public GameObject coin_count_display;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coin_count_display.GetComponent<Text>().text = "" + coin_count;
    }
}
