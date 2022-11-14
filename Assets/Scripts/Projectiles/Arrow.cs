using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D arrowRB;
    public Vector3 shootDir;
    public const int speed = 10;
    public SpriteRenderer arrowSprite;

    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
        float rotate = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        if (rotate < 0) {
            rotate += 360;
        }
        transform.eulerAngles = new Vector3(0, 0, rotate);
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        float moveSpeed = 10f;
        transform.position += shootDir * (moveSpeed * Time.deltaTime);
        arrowRB.velocity = transform.right * speed;
    }
    
}
