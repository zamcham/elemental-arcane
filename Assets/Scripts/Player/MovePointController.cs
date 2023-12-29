using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointController : MonoBehaviour
{
    PlayerController playerController;
    public bool playerCanMove;

    [SerializeField] LayerMask notWalkable;
    [SerializeField] LayerMask enemyLayer;

    GameObject enemy;

    void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            enemy = other.gameObject;
        }
    }

    public void MoveChecker(Vector3 inputVector) {
        
        Vector3 targetHorizontalPos = new Vector3(inputVector.x, 0f, 0f);
        Vector3 targetVerticalPos = new Vector3(0f, inputVector.y, 0f);

        //If player is at the same position as the move point
        if (Vector3.Distance(playerController.gameObject.transform.position, transform.position) <= 0.01f)
        {
            if (Mathf.Abs(inputVector.x) == 1f)
            {
                if (!Physics2D.OverlapCircle(transform.position + targetHorizontalPos, 0.2f, notWalkable))
                {
                    if (LevelManager.instance.IsInDanger())
                    {
                        List<Vector3> dangerZones = LevelManager.instance.GetDangerZones();
                        Vector3 futurePosition = transform.position + targetHorizontalPos;

                        if (dangerZones.Contains(futurePosition))
                        {
                            // Future position is in a danger zone
                            LevelManager.instance.SetEnemyMoveFalse();
                            Debug.Log("Player will move into a danger zone!");
                            
                        }
                        else
                        {
                            LevelManager.instance.SetEnemyMoveTrue();
                        }

                        transform.position += targetHorizontalPos;
                    }
                    else
                    {
                        LevelManager.instance.SetEnemyMoveTrue();
                        transform.position += targetHorizontalPos;
                        playerCanMove = true;
                    }
                }
            }
            else if (Mathf.Abs(inputVector.y) == 1f)
            {
                if (!Physics2D.OverlapCircle(transform.position + targetVerticalPos, 0.2f, notWalkable))
                {
                    if (LevelManager.instance.IsInDanger())
                    {
                        List<Vector3> dangerZones = LevelManager.instance.GetDangerZones();
                        Vector3 futurePosition = transform.position + targetVerticalPos;

                        if (dangerZones.Contains(futurePosition))
                        {
                            // Future position is in a danger zone
                            LevelManager.instance.SetEnemyMoveFalse();
                            Debug.Log("Player will move into a danger zone!");
                            
                        }
                        else
                        {
                            LevelManager.instance.SetEnemyMoveTrue();
                        }

                        transform.position += targetVerticalPos;
                    }
                    else
                    {
                        LevelManager.instance.SetEnemyMoveTrue();
                        transform.position += targetVerticalPos;
                        playerCanMove = true;
                    }
                }
            }
        }
    }
}
