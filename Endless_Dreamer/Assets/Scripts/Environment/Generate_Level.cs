using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generate_Level : MonoBehaviour
{
    public GameObject[] obsticles;
    public GameObject section;
    public GameObject[] collectables;
    public float[] collectables_y;

    public int z_pos = 50;
    private bool creating_section = false;

    public int obj_num;
    public int obj_z_pos = 0;
    private bool creating_object = false;

    public int coin_num;
    public int coin_z_pos = 0;
    private bool creating_collectables = false;
    public int c;
    public int l;

    public float[] lane_x_pos;
    public int x;
    public float[] y_pos;

    public GameObject spawn;
    private GameObject player;
    public GameObject cloud;
    public GameObject cam;

    public Collectable_Control control;
    public Player_Move player_move;

    public GameObject potionPanel;
    void Start()
    {
        //spawning in the currently selected character
        player = Instantiate(GameManager.manager.characters[GameManager.manager.currentCharacter], spawn.transform);
        player_move = player.GetComponent<Player_Move>();
        Instantiate(cloud, player.transform);
        Instantiate(cam, player.transform);

        //assigning the spawned character to the distance tracker in Collectable_Control
        control.player = player;
        control.player_move = player_move;
        control.speedPower = player.GetComponent<SpeedPower>();

        //using a score potion
        if (GameManager.manager.yellowPotion >= 1)
        {
            Time.timeScale = 0f;
            potionPanel.SetActive(true);
        }
    }
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

        if (creating_collectables == false)
        {
            creating_collectables = true;
            StartCoroutine(Generating_collectables());
        }
    }
    
    IEnumerator Generating_section()
    {
        Instantiate(section, new Vector3(0,0,z_pos), Quaternion.identity);
        z_pos += 50;
        yield return new WaitForSeconds(40/player_move.move_speed);
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
        obj_z_pos += 20;
        yield return new WaitForSeconds(15/player_move.move_speed);
        creating_object = false;
    }

    IEnumerator Generating_collectables()
    {
        coin_num = Random.Range(0, 1);
        l = Random.Range(0, 3);
        c = Random.Range(0, collectables.Length);
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
                Instantiate(collectables[1], new Vector3(lane_x_pos[l], collectables_y[c], coin_z_pos), Quaternion.identity);
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
                Instantiate(collectables[1], new Vector3(lane_x_pos[l], collectables_y[c], coin_z_pos), Quaternion.identity); // else spawn arch on top of obj
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
                Instantiate(collectables[c], new Vector3(lane_x_pos[l], collectables_y[c], coin_z_pos), Quaternion.identity);
            }
        }
        coin_z_pos += 20;
        yield return new WaitForSeconds(15/player_move.move_speed);
        creating_collectables = false;
    }

}
