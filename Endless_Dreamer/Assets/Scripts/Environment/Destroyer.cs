using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parent_name;

    public Player_Move player_move;
    public Generate_Level generate_Level;

    // Start is called before the first frame update
    void Start()
    {
        player_move = generate_Level.player_move;
    }

    // Update is called once per frame
    void Update()
    {
        parent_name = transform.name;
        StartCoroutine(Destroy_Section_Clone());
        StartCoroutine(Destroy_Object_Clone());
    }

    IEnumerator Destroy_Section_Clone()
    {
        yield return new WaitForSeconds(45);
        if (parent_name == "Forest_Section(Clone)")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Destroy_Object_Clone()
    {
      yield return new WaitForSeconds(10 / player_move.move_speed);
      if (parent_name == "Rock(Clone)" || parent_name == "Tree(Clone)" || parent_name == "Tree_Stump(Clone)" || parent_name == "Fallen_Tree(Clone)")
      {
          Destroy(gameObject);
      }
    }
    // not only does this not destroy the objects, (i guess it doesnt take the obj_s into account??) but if it would it would destroy all the trees made?
    // maybe it does work and it's deleting random objects from the middle bc i saw that some are closer and some ore farther apart. bc it does say if rock OR. so maybe it deletes all rocks first?
    // i need to put them in a list and delete the list items from the oldest... but they all spawn at the same time...
    // is this obj_s the same as the one from geenrate level? if not how do i make it be the same?
}

