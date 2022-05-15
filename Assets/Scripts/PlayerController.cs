using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event EventHandler OnShoot;
    public float moveSpeed = 5f;
    public Rigidbody2D playerRB;
    public Animator animator; 
    Vector2 movement;
    private Camera theCam;

    private void Awake()
    {
        
        theCam = Camera.main;
    }
    
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerAim();
    }

    private void PlayerAim() {
        if (Input.GetMouseButton(0)) {
            //Calculates the mouse position in a 2D world and adjusts 
            Vector3 mousePos = Input.mousePosition;
            Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);
            Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
 
            animator.SetBool("Left Mouse Down", true);
            animator.SetFloat("Angle", angle);
           
        }

        if (!Input.GetMouseButton(0)) {
            playerRB.SetRotation(quaternion.Euler(0f, 0f, 0f));
            animator.SetBool("Left Mouse Down", false);
        }
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
}
