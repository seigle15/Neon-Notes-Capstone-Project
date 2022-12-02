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
    //Movement Variables
    [FormerlySerializedAs("animator")] public Animator PlayerAnimator;
    public float moveSpeed = 6f; 
    public Rigidbody2D playerRB;
    private Vector2 movement;
    private Vector3 lastMove;
    private Camera theCam;
    
    //Attack and special variables
    [SerializeField] private LayerMask specialLayerMask;
    private Quaternion attackAngle;
    public Transform aimTransform;
    private bool isOnSpecial;
    private Vector3 mousePos;
    public float specialCoolDown = 1f;
    public float specialCounter;

    public RhythmController beatChecker;
    public event EventHandler<PositionArgs> OnPlayerAttack;
    
    public class PositionArgs : EventArgs
    {
        public Vector2 attackPos;
        public Vector3 attackDirection;
    }
    
    //Health variables
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBar;
    
    private void Awake()
    {
        theCam = Camera.main;
        aimTransform = transform.Find("Aim");
        playerRB = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    // Update is called once per frame
    void Update() 
    {

        mousePos = theCam.ScreenToWorldPoint(Input.mousePosition) - transform.localPosition;
        PlayerMovement();
        PlayerAim();
        if (specialCounter > 0)
        {
            specialCounter -= Time.deltaTime;
        }

        //&& beatChecker.getBeat()
        if (Input.GetMouseButtonDown(0) && beatChecker.getBeat()) {
            OnPlayerAttack?.Invoke(this, new PositionArgs{attackPos = aimTransform.position, 
                attackDirection = mousePos});
            beatChecker.setBeat(false);
        }

        if (Input.GetMouseButtonDown(1) && specialCounter <= 0)
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
        if (movement.x != 0 || movement.y != 0)
        {
            lastMove = movement;
        }

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
            Vector3 dashPos = transform.position + lastMove * dashAmount;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(
                transform.position, lastMove, dashAmount, specialLayerMask);
            if (raycastHit2D.collider != null)
            {
                dashPos = raycastHit2D.point;
            }
            playerRB.MovePosition(dashPos);
            isOnSpecial = false;
            specialCounter = specialCoolDown;
        }
        
    }
    
    
    
}
