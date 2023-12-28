using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    float moveSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

     void Move()
    {
        Vector3 targetHorizontalPos = new Vector3(moveInput.x, 0f, 0f);
        Vector3 targetVerticalPos = new Vector3(0f, moveInput.y, 0f);
        

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }
}

