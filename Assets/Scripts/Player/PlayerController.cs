using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    MovePointController movePointController;
    [SerializeField] Transform movePoint;
    [SerializeField] float moveSpeed;
    Vector2 moveInput;
    bool canMove;

    void Awake()
    {
        movePointController = GetComponentInChildren<MovePointController>();
    }

    void Start()
    {
        movePoint.parent = null;
        moveSpeed = LevelManager.instance.GetCharactersMoveSpeed();
    }

    void Update()
    {
        canMove = movePointController.playerCanMove;
        Move();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        LevelManager.instance.SetEnemyMoveTrue();
        movePointController.MoveChecker(moveInput);
    }

    void Move()
    {   
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        }
    }

    public Vector2 GetInputVector()
    {
        return moveInput;
    }
}
