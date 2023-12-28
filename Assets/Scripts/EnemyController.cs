using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public float moveSpeed;
    public List<Vector3> path;
    private int currentWaypoint = 0;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Start()
    {
        moveSpeed = LevelManager.instance.GetCharactersMoveSpeed();
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
                CalculatePath();  
            }
        }
    }

}
