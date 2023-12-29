using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public bool enemyCanMove;
    bool playerInDanger;
    List<Vector3> dangerZones = new List<Vector3>();

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

    public void PlayerInDanger(List<Vector3> dangerZones)
    {
        playerInDanger = true;
        this.dangerZones = dangerZones;
    }

    public bool IsInDanger()
    {
        return playerInDanger;
    }

    public List<Vector3> GetDangerZones()
    {
        return dangerZones;
    }

}
