using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask notWalkable;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float moveSpeed;
    Vector2 moveInput;

    void Start()
    {
        movePoint.parent = null;
        moveSpeed = LevelManager.instance.GetCharactersMoveSpeed();
    }

    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        LevelManager.instance.SetEnemyMoveTrue();
    }

    void Move()
    {
        Vector3 targetHorizontalPos = new Vector3(moveInput.x, 0f, 0f);
        Vector3 targetVerticalPos = new Vector3(0f, moveInput.y, 0f);
        
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f)
        {
            Collider2D enemyCollider = Physics2D.OverlapCircle(movePoint.position + targetHorizontalPos, 0.2f, enemyLayer);

            if (Mathf.Abs(moveInput.x) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + targetHorizontalPos, 0.2f, notWalkable))
                {
                    movePoint.position += targetHorizontalPos;
                }
                else if (enemyCollider != null)
                {
                    Debug.Log("Enemy hit");
                }

            }
            else if (Mathf.Abs(moveInput.y) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + targetVerticalPos, 0.2f, notWalkable))
                {
                    movePoint.position += targetVerticalPos;
                }
                else if (enemyCollider != null)
                {
                    Debug.Log("Enemy hit");
                }
            }
        }
    }
}
