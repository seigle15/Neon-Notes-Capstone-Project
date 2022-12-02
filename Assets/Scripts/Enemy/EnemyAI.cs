using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    private Path path;
    private int currentWaypoint = 0;
    private bool reachEndOfPath = false;
    private Seeker seeker;
    private Rigidbody2D rb;

    public int attackDamage = 5;
    public float attackRange = 2f;
    public Transform enemyAim;
    [SerializeField]
    public EnemyAnimation animation;

    [SerializeField] private int maxHealth = 10;
    public int health = 10;
    
    private Vector3 startingPosition;

    public static event Action<EnemyAI> OnDamageEnemy;
    // Start is called before the first frame update
    void Start()
    {
        //startingPosition = GetSpawnPoint();
        startingPosition = transform.position;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        //animation = GameObject.FindGameObjectWithTag("GFX");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        //path finding
        if (path == null)
            return;
        
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;
        } else
        {
            reachEndOfPath = false;
        }
        
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position ).normalized;
        Vector2 force = direction * (Time.deltaTime *speed);
        rb.AddForce(force);
        animation.UpdateMovement(force);
        animation.UpdateSpeed(speed);
        
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWayPointDistance)
        {
            currentWaypoint++;
        }
        //end of path finding 
        
    }

    private void Update()
    {
        EnemyAim();
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            animation.CheckRange(true);
            animation.AttackInfo(attackRange, attackDamage);
        }
        else
        {
            animation.CheckRange(false);
        }
        
    }

    private void EnemyAim()
    {
        Vector3 targetPos = target.position;
        float angleZ = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        enemyAim.eulerAngles = new Vector3(0, 0, angleZ);
    }
    public void TakeDamge(int damage)
    {
        health -= damage;
        animation.EnemyHit();
        OnDamageEnemy?.Invoke(this);
        if (health <= 0)
        {
            animation.EnemyDeath();
            //speed = 0;
            Destroy(gameObject, 1f);
        }

    }
    

}
