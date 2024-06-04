using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float move_speed = 3;
    public float left_right_speed = 4;
    static public bool can_move = false;
    public bool is_jumping = false;
    public bool coming_down = false;
    public GameObject player_object;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * move_speed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > Level_Boundry.left_side)
            {
                transform.Translate(Vector3.left * Time.deltaTime * left_right_speed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < Level_Boundry.right_side)
            {   
                transform.Translate(Vector3.right * Time.deltaTime * left_right_speed);
            }
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (is_jumping == false)
            {
                is_jumping = true;
                player_object.GetComponent<Animator>().Play("Jump");
                StartCoroutine(Jump_sequence());
            }
        }

        if(is_jumping == true)
        {
            if(coming_down == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World); //make the 3 a variable?
            }
            if (coming_down == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World); //make the 3 a variable?
            }
        }
    }

    IEnumerator Jump_sequence()
    {
        yield return new WaitForSeconds(0.45f);
        coming_down = true;
        yield return new WaitForSeconds(0.45f);
        is_jumping = false;
        coming_down = false;
        player_object.GetComponent<Animator>().Play("Standard Run");
    }
}
