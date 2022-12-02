using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform aim;
    [SerializeField]
    public HealthBar playerHealth;
    private void Awake()
    {
        
        EnemyAnimation enemy = GetComponent<EnemyAnimation>();
        enemy.OnEnemyAttack += Skeleton_Melee;
        //playerHealth = 
    }

    private void Skeleton_Melee(object sender, EnemyAnimation.PositionArgs e)
    {
        Collider2D colInfo = Physics2D.OverlapCircle(e.position, e.attackRange, e.mask);
        if (colInfo.GetComponent<Health>() != null)
        {
            Health health = colInfo.GetComponent<Health>();
            health.Damage(e.damage);
            playerHealth.TakeDamage(e.damage);
        }
    }
    
}
