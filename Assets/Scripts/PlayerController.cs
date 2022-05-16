using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public Transform aimTransform;
    public float moveSpeed = 5f;
    public Rigidbody2D playerRB;
    public Animator animator; 
    Vector2 movement;
    private Camera theCam;
    public GameObject arrow;

    private void Awake()
    {
        theCam = Camera.main;
        aimTransform = transform.Find("Aim");

    }
    
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerAim();
        ShootProjectile();
    }

    private void PlayerAim() {
        //Calculates the mouse position in a 2D world and adjusts 
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        

        if (Input.GetMouseButton(0)) {
            animator.SetBool("Left Mouse Down", true);
            animator.SetFloat("Angle", angle);
            
        }

        if (!Input.GetMouseButton(0)) {
            animator.SetBool("Left Mouse Down", false);
        }

        aimTransform.rotation = Quaternion.Euler(0f, 0f, angle);


    }

    private void PlayerMovement() {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    private void FixedUpdate() {
        //movement
        playerRB.MovePosition(playerRB.position  + movement * moveSpeed * Time.fixedDeltaTime);
        
    }

    private void ShootProjectile()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(arrow, aimTransform.position, aimTransform.rotation);
        }
    }
    
}
