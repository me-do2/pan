using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [Header("速さ")] public float speed = 5.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, speed));
    }
}
