using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    [SerializeField] private Transform pfArrow;
    
    private void Awake()
    {
        PlayerController pc = GetComponent<PlayerController>();
        pc.OnPlayerAttack += ShootProjectiles_ShootArrow;
    }

    private void ShootProjectiles_ShootArrow(object sender, PlayerController.PositionArgs e)
    {
        Transform arrow = Instantiate(pfArrow, e.attackPos, Quaternion.identity);
        arrow.GetComponent<Arrow>().Setup(e.attackDirection);
    }
}
