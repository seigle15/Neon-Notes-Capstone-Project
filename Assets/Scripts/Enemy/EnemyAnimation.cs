using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator enemyAnimator;
    public LayerMask attackMask;
    public EventHandler<PositionArgs> OnEnemyAttack;
    private bool enemyDead = false;
    private float enemyRange;
    private int enemyDamage;


    public class PositionArgs : EventArgs
    {
        public Vector2 position;
        public float attackRange;
        public int damage;
        public LayerMask mask;
    }

    private void Awake()
    {
        enemyDead = false;
    }

    // Update is called once per frame
    //Called during animation 
    public void Attack()
    {
        OnEnemyAttack?.Invoke(this, new PositionArgs
        {
            position = transform.position,
            attackRange = enemyRange,
            mask = attackMask,
            damage = enemyDamage
        });
        
    }

    public void UpdateMovement(Vector2 moveDir)
    {
        if (moveDir.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 0);
        }
        if (moveDir.x <= -0.01f)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 0);
        }
        
    }

    public void UpdateSpeed(float speed)
    {
        /*if(!enemyDead)*/
            enemyAnimator.SetFloat("Speed", speed);
    }
    
    public void CheckRange(bool inRange)
    {
        /*if(!enemyDead)*/
            enemyAnimator.SetBool("AttackRange", inRange);
    }

    public void EnemyHit()
    {
        /*if(!enemyDead)*/
            enemyAnimator.SetTrigger("Damage");
    }

    public void EnemyDeath()
    {
        enemyDead = true;
        enemyAnimator.SetTrigger("Death");
    }

    public void RemoveEnemy()
    {
        //transform.parent
        
        Destroy(gameObject);
    }

    public void AttackInfo(float range, int damage)
    {
        enemyRange = range;
        enemyDamage = damage;
    }
}
