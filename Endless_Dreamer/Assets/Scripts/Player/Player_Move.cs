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
    //Colliding with obstacles
    void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.gameObject.CompareTag("Obstacle"))
        {
            //coin_FX.Play();
            obstacle.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<Player_Move>().enabled = false;
            animator.SetTrigger("Stumble");
            panel.SetActive(true);
        }

        if (obstacle.gameObject.CompareTag("Coin"))
        {
            coin_FX.Play();
            Collectable_Control.coin_count += 1;
            obstacle.gameObject.SetActive(false);
        }

        if (obstacle.gameObject.CompareTag("Gem"))
        {
            coin_FX.Play();
            Collectable_Control.gem_count += 1;
            obstacle.gameObject.SetActive(false);
        }
    }
}