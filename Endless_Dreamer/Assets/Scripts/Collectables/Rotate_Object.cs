using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Object : MonoBehaviour
{
    public int rotate_speed = 1;

    void Update()
    {
        transform.Rotate(0, rotate_speed, 0, Space.World);
    }
}
