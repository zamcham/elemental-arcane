using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public float moveSpeed = 1f; // Adjust the speed as needed
    public List<Vector3> path;
    private int currentWaypoint = 0;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Start()
    {
        CalculatePath();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CalculatePath()
    {
        // Use A* algorithm to calculate the path
        // You can implement your own A* algorithm or use a library like AstarPathfindingProject

        // For this example, a simple straight line path is calculated
        path = new List<Vector3>();
        Vector3 currentPos = transform.position;

        while (currentPos != player.position)
        {
            if (currentPos.x > player.position.x)
            {
                currentPos.x--;
            }
            else if (currentPos.x < player.position.x)
            {
                currentPos.x++;
            }
            else if (currentPos.y > player.position.y)
            {
                currentPos.y--;
            }
            else if (currentPos.y < player.position.y)
            {
                currentPos.y++;
            }

            path.Add(currentPos);
        }

        // Reverse the path to move from the enemy to the player
        path.Reverse();

        // Reset the waypoint index
        currentWaypoint = 0;
    }

}
