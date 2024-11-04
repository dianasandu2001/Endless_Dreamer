using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float move_speed = 3;
    public float left_right_speed = 4;

    public GameObject player_object;

    public bool grounded;
    public Rigidbody RB;
    public float jump_force;
    public Animator animator;

    //public AudioSource coin_FX;
    //public GameObject stumble_animation;
    public GameObject panel;
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

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            RB.linearVelocity = new Vector2(0, jump_force);
            //nimator.SetTrigger("JumpT");
            //player_object.GetComponent<Animator>().Play("Jump");
        }
    }
    
    void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.gameObject.CompareTag("Obstacle"))
        {
            //coin_FX.Play();
            obstacle.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<TestMove>().enabled = false;
            animator.SetTrigger("Stumble");
            //stumble_animation.GetComponent<Animator>().Play("Stumble Backwards");
            panel.SetActive(true);
        }
    }
    
    private void OnCollisionEnter(Collision ground)
    {
        if (ground.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("Jump", false);
            //animator.SetTrigger("JumpT");
        //player_object.GetComponent<Animator>().Play("Standard Run");
        }
    }
    private void OnCollisionExit(Collision ground)
    {
        if (ground.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            animator.SetBool("Jump", true);
            animator.SetTrigger("JumpT");
        }
    }
}