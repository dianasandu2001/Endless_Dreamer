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

    public float[] lane_x_pos;
    public int x;
    public float[] y_pos;

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
        x = Random.Range(0, 3);
        if (obj_num == 2)
        {
            Instantiate(obsticles[obj_num], new Vector3(0, y_pos[obj_num], obj_z_pos), Quaternion.identity);
        }
        else
        {
            Instantiate(obsticles[obj_num], new Vector3(lane_x_pos[x], y_pos[obj_num], obj_z_pos), Quaternion.identity);
        }
        obj_z_pos += 10;
        yield return new WaitForSeconds(seconds);
        creating_section = false;
    }

    //IEnumerator Generating_coins()
    //{
        //obj_num = Random.Range(0, 2);
        //x = Random.Range(0, 3);
        //if (obj_num == 2)
        //{
            //Instantiate(obsticles[obj_num], new Vector3(0, y_pos[obj_num], obj_z_pos), Quaternion.identity);
        //}
        //else
        //{
            //Instantiate(obsticles[obj_num], new Vector3(lane_x_pos[x], y_pos[obj_num], obj_z_pos), Quaternion.identity);
        //}
        //obj_z_pos += 10;
        //yield return new WaitForSeconds(seconds);
        //creating_section = false;
    //}
}
