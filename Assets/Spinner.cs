using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Vector3 spin;
    public float speed = 1;
    void Update()
    {
        transform.Rotate(spin * speed);
    }
}
