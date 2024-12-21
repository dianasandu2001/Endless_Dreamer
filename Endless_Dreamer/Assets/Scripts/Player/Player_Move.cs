using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    //Moving variables
    public float move_speed;
    public float left_right_speed;
    public float speed_increase_rate;

    //Jumping variables
    public bool grounded;
    public Rigidbody RB;
    public float jump_force;
    public Animator animator;

    public bool tripped;

    // Ground check variables
    public Transform ground_check_position;  // Reference to the position where the ray starts (e.g., under the player's feet)
    public float ground_check_distance = 0.2f;  // How far to cast the ray
    public LayerMask ground_layer;  // Layers considered as "ground"

    //Colliding variables
    //public AudioSource coin_FX;
    public GameObject panel;

    public AudioSource coin_FX;
    public bool isProtectedByBubble = false;

    private float jt = 1f;

    void Update()
    {
        // checking animations state for debugging
        //AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //Debug.Log("Current State: " + stateInfo.shortNameHash);


        if (move_speed < 15)
        {
            // Gradually increase move_speed
            move_speed += speed_increase_rate * Time.deltaTime;
        }
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

        // grounded
        if (Time.realtimeSinceStartup - jt > 0.1f)
        {
            grounded = Physics.Raycast(ground_check_position.position, Vector3.down, ground_check_distance, ground_layer);
        }

        // Jumping
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            jt = Time.realtimeSinceStartup;
            grounded = false;
            RB.linearVelocity = new Vector2(0, jump_force);
            animator.SetTrigger("Jump");
        }
    }

    private void OnDrawGizmos()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(ground_check_position.position, ground_check_position.position + Vector3.down * ground_check_distance);
    }
}