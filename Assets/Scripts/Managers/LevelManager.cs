using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public bool enemyCanMove;
    bool playerInDanger;

    [SerializeField] float charactersMoveSpeed;

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

    public void SetEnemyMoveTrue()
    {
        enemyCanMove = true;
        Debug.Log("Enemy can move");
    }

    public void SetEnemyMoveFalse()
    {
        enemyCanMove = false;
    }

    public bool MoveEnemy()
    {
        return enemyCanMove;
    }

    public float GetCharactersMoveSpeed()
    {
        return charactersMoveSpeed;
    }

    //Check if the player is in danger
    // if it;s in danger the next time they move, check if they moved
    // into a danger zone
    // if they did, then they die
    // if they didn't, then they're safe
    public void PlayerInDanger(bool danger)
    {
        playerInDanger = danger;
    }

    

}
