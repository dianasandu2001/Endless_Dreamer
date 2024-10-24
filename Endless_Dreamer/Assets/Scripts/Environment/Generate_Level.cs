using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Level : MonoBehaviour
{
    public GameObject[] obsticles;
    public GameObject section;
    public GameObject[] coins;

    public int z_pos = 50;
    public bool creating_section = false;
    public float sec_s;

    public int obj_num;
    public int obj_z_pos = 0;
    public bool creating_object = false;
    public float obj_s;

    public int coin_num;
    public int coin_z_pos = 0;
    public bool creating_coins = false;
    public float coin_s;
    public float coin_y_pos;
    public int c;
    public int l;

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
            creating_object = true;
            StartCoroutine(Generating_obsticle());
        }

        if (creating_coins == false)
        {
            creating_coins = true;
            StartCoroutine(Generating_coins());
        }
    }
    
    IEnumerator Generating_section()
    {
        Instantiate(section, new Vector3(0,0,z_pos), Quaternion.identity);
        z_pos += 50;
        yield return new WaitForSeconds(sec_s);
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
        yield return new WaitForSeconds(obj_s);
        creating_object = false;
    }
    // all objects spawn at the same time :(

    IEnumerator Generating_coins()
    {
        coin_num = Random.Range(0, 1);
        l = Random.Range(0, 3);
        c = Random.Range(0, 3);
        // can add more and more ad i add diamonds and such so they can spawn here
        // for example from 0 to 20, assign 7 of them to coin line, 1 to the arch, 1 to diamond, 1 chest, 2 powerup and 8 to nothing

        if (obj_num == 2) // if obj is a log
        {
            if (c != 1)
            {
                //aka if the coins that would spawn would be anything but the arch (CHANGE if i add more variables to be the coin arch)
            }
            else
            {
                Instantiate(coins[1], new Vector3(lane_x_pos[l], coin_y_pos, coin_z_pos), Quaternion.identity);
            }
        }
        else if (x == l) // if object and coins spawn in the same place
        {
            if (obj_num == 1) // if obj = tree
            {
                //do nothing, to prevent the coins and trees from spawning on top of each other
            }
            else
            {
                Instantiate(coins[1], new Vector3(lane_x_pos[l], coin_y_pos, coin_z_pos), Quaternion.identity); // else spawn arch on top of obj
            }
        }
        else
        {
            if (c == 1)
            {
                //aka if the coins that would spawn would be anything but the arch (CHANGE if i add more variables to be the coin arch)
            }
            else
            {
                Instantiate(coins[c], new Vector3(lane_x_pos[l], coin_y_pos, coin_z_pos), Quaternion.identity);
            }
        }
        coin_z_pos += 10;
        yield return new WaitForSeconds(coin_s);
        creating_coins = false;
    }

    // im having problems coming up with something that says, if object and coin are in the same place, spawn coin or something like that
}
