using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Level : MonoBehaviour
{
    public GameObject[] obsticles;
    public GameObject section;
    public int z_pos = 50;
    public bool creating_section = false;
    public float seconds;

    public int obj_num;
    public int obj_z_pos = 0;
    public bool creating_object = false;

    void Update()
    {
        if (creating_section == false)
        {
            creating_section = true;
            StartCoroutine(Generating_section());
        }

        if (creating_object == false)
        {
            creating_section = true;
            StartCoroutine(Generating_obsticle());
        }
    }
    
    IEnumerator Generating_section()
    {
        Instantiate(section, new Vector3(0,0,z_pos), Quaternion.identity);
        z_pos += 50;
        yield return new WaitForSeconds(seconds);
        creating_section = false;
    }

    IEnumerator Generating_obsticle()
    {
        obj_num = Random.Range(0, 4);
        Instantiate(obsticles[obj_num], new Vector3(0, 1, obj_z_pos), Quaternion.identity);
        obj_z_pos += 5;
        yield return new WaitForSeconds(seconds);
        creating_section = false;
    }
}
