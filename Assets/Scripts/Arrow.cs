using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D arrowRB;
    private void Update()
    {
        arrowRB.velocity = transform.right * speed;
    }
}
