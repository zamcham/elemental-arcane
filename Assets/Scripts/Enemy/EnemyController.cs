using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public List<Vector3> path;
    private int currentWaypoint = 0;
    bool triggeredDangerZone;
    public List<Vector3> dangerZones;

    bool isAttacking;
    int turnsToAttack;
    int currentTurn;
    int turnsInAttackMode;
    int remainingTurnsInAttackMode;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
        moveSpeed = LevelManager.instance.GetCharactersMoveSpeed();
        turnsToAttack = Random.Range(2, 4);
        currentTurn = 0;
        turnsInAttackMode = Random.Range(1, 3);
        remainingTurnsInAttackMode = turnsInAttackMode;
    }

    void Start()
    {
        CalculatePath();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.MoveEnemy())
        {
            Move();
        }

    }

    void Move()
    {
        if (path != null && currentWaypoint < path.Count)
        {
            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, path[currentWaypoint], moveSpeed * Time.deltaTime);

            // Check if the enemy has reached the current waypoint
            if (Vector3.Distance(transform.position, path[currentWaypoint]) < 0.01f)
            {
                transform.position = path[currentWaypoint];
                LevelManager.instance.SetEnemyMoveFalse();
                GenerateDangerZones();
                CalculatePath(); 
                ToggleAttackMode(); 
            }
        }
    }

    void CalculatePath()
    {
        path = new List<Vector3>();
        Vector3 currentPos = transform.position;
        float deltaX = Mathf.Abs(player.position.x - currentPos.x);
        float deltaY = Mathf.Abs(player.position.y - currentPos.y);

        for (int i = 0; i < 2; i++)
        {
            if (deltaX > deltaY)
            {
                if (currentPos.x > player.position.x)
                {
                    currentPos.x--;
                }
                else if (currentPos.x < player.position.x)
                {
                    currentPos.x++;
                }
                }
            else
            {
                if (currentPos.y > player.position.y)
                {
                    currentPos.y--;
                }
                else if (currentPos.y < player.position.y)
                {
                    currentPos.y++;
                }
            }

            path.Add(currentPos);
        }

        currentWaypoint = 0;
    }

    void GenerateDangerZones()
    {
        dangerZones = new List<Vector3>();

        dangerZones.Add(transform.position + new Vector3(1f, 0f, 0f)); // +1 on the x
        dangerZones.Add(transform.position + new Vector3(-1f, 0f, 0f)); // -1 on the x
        dangerZones.Add(transform.position + new Vector3(0f, 1f, 0f)); // +1 on the y
        dangerZones.Add(transform.position + new Vector3(0f, -1f, 0f)); // -1 on the y
    }
    
    void ToggleAttackMode()
    {
        if (currentTurn >= turnsToAttack)
        {
            if (remainingTurnsInAttackMode > 0)
            {
                isAttacking = true;
                Debug.Log("Enemy is attacking!");
                LevelManager.instance.PlayerInDanger(dangerZones);
                remainingTurnsInAttackMode--;
            }
            else
            {
                // Reset attack mode
                isAttacking = false;
                currentTurn = 0;
                remainingTurnsInAttackMode = turnsInAttackMode;
            }
        }
        else
        {
            isAttacking = false;
            currentTurn++;
        }
    }
}


