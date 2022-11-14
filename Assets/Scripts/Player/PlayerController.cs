using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public Transform aimTransform;
    public float moveSpeed = 6f; 
    public Rigidbody2D playerRB;
    [FormerlySerializedAs("animator")] public Animator PlayerAnimator;
    Vector2 movement;
    private bool isOnSpecial;
    private Camera theCam;
    private Vector3 mousePos;
    private Quaternion attackAngle;
    public event EventHandler<PositionArgs> OnPlayerAttack;
    

    public class PositionArgs : EventArgs
    {
        public Vector2 attackPos;
        public Vector3 attackDirection;
    }

    private void Awake()
    {
        theCam = Camera.main;
        aimTransform = transform.Find("Aim");
        playerRB = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update() 
    {
        
        mousePos = theCam.ScreenToWorldPoint(Input.mousePosition) - transform.localPosition;
        PlayerMovement();
        PlayerAim();

        //RhythmController.OnBeat();
        if (Input.GetMouseButtonDown(0)) {
            OnPlayerAttack?.Invoke(this, new PositionArgs{attackPos = aimTransform.position, 
                attackDirection = mousePos});
        }

        if (Input.GetMouseButtonDown(1))
        {
            isOnSpecial = true;
        }
    }

    private void PlayerAim() {
        //Calculates the mouse position in a 2D world and adjusts 
        Vector3 rotation = mousePos;
        float angleZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angleZ);

        if (!Input.GetMouseButton(0)) {
            PlayerAnimator.SetBool("Left Mouse Down", false);
        }
        
        if (Input.GetMouseButton(0)) {
            PlayerAnimator.SetBool("Left Mouse Down", true);
            PlayerAnimator.SetFloat("Angle", angleZ);
        }
        
    }

    private void PlayerMovement() {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        PlayerAnimator.SetFloat("Horizontal", movement.x);
        PlayerAnimator.SetFloat("Vertical", movement.y);
        PlayerAnimator.SetFloat("Speed", movement.sqrMagnitude);

    }
    private void FixedUpdate() {
        //movement
        playerRB.velocity = movement.normalized * moveSpeed;
        if (isOnSpecial)
        {
            float dashAmount = 2f;
            playerRB.MovePosition((Vector2)transform.position + movement * dashAmount);
            isOnSpecial = false;
        }
        
    }
    
    
}
