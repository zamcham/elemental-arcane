using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    LevelManager instance;
    bool enemyCanMove;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggeleEnemyMovementBool()
    {
        enemyCanMove = !enemyCanMove;
    }

    public void enemyCanMove()
    {
        return enemyCanMove;
    }
}
