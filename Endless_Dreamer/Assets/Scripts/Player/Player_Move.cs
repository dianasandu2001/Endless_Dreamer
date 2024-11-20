using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    //Moving variables
    public float move_speed = 3;
    public float left_right_speed = 4;

    //Jumping variables
    public bool grounded;
    public Rigidbody RB;
    public float jump_force;
    public Animator animator;

    //Colliding variables
    //public AudioSource coin_FX;
    public GameObject panel;

    public AudioSource coin_FX;
    public bool isProtectedByBubble = false;

    void Update()
    {
        //Continuous running
        transform.Translate(Vector3.forward * Time.deltaTime * move_speed, Space.World);

        //Moving left-right
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

        //Jumping
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            RB.linearVelocity = new Vector2(0, jump_force);
            animator.SetBool("Jump", true);
        }
    }
    private void OnCollisionEnter(Collision ground)
    {
        if (ground.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("Jump", false);
        }
    }
    private void OnCollisionExit(Collision ground)
    {
        if (ground.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}