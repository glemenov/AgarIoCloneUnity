using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private EnemyBehaviour enemyRef;
    void Awake()
    {
        enemyRef = GetComponentInParent<EnemyBehaviour>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Food")
        {
            if(enemyRef.target == null)
                enemyRef.target = collision.gameObject;
        }

        if (collision.transform.tag == "Player")
        {
            if(enemyRef.score > GameHandler.GH.score)
            {
                //follow
                enemyRef.target = collision.gameObject;
                Debug.Log("Player is detected - Chasing!");

            } else if (enemyRef.score < GameHandler.GH.score)
            {
                
            }
        }
    }
}
