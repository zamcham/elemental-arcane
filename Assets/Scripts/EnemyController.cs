using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    PlayerController player;
    transform playerPosition;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTargetPosition()
    {
        playerPosition = player.transform;
    }

}
