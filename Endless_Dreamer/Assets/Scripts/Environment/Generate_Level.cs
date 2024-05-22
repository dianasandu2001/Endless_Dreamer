using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Level : MonoBehaviour
{
    public GameObject[] section;
    public int z_pos = 50;
    public bool creating_section = false;
    public int sec_num;
    public float seconds;

    void Update()
    {
        if (creating_section == false)
        {
            creating_section = true;
            StartCoroutine(Generating_section());
        }
    }
    
    IEnumerator Generating_section()
    {
        sec_num = Random.Range(0, 3);
        Instantiate(section[sec_num], new Vector3(0,0,z_pos), Quaternion.identity);
        z_pos += 50;
        yield return new WaitForSeconds(seconds);
        creating_section = false;
    }
}
