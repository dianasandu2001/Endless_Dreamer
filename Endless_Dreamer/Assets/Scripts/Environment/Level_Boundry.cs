using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Boundry : MonoBehaviour
{
    public static float left_side = -2f;
    public static float right_side = 2f;
    public float internal_left;
    public float internal_right;

    // Update is called once per frame
    void Update()
    {
        internal_left = left_side;
        internal_right = right_side;

    }
}
