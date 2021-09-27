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
        // Checking collision with the food
        if (collision.transform.tag == "Food")
        {
            // If current target is null, then set the food as target, and change state to Chase
            if (enemyRef.target == null)
            {
                enemyRef.target = collision.gameObject;
                enemyRef.currentState = EnemyBehaviour.enemyState.Chase;
            }
        }

        if (collision.transform.tag == "Player")
        {
            enemyRef.target = collision.gameObject;

            // If enemy score is bigger - Chase
            if (enemyRef.score > GameHandler.GH.score)
            {
                enemyRef.currentState = EnemyBehaviour.enemyState.Chase;

            } else if (enemyRef.score < GameHandler.GH.score)
            {
                // Or flee, if otherwise
                enemyRef.currentState = EnemyBehaviour.enemyState.Flee;
            }
        }

        if (collision.transform.tag == "Enemy")
        {
            enemyRef.target = collision.gameObject;

            // If enemy score is bigger - Chase
            if (enemyRef.score > collision.gameObject.GetComponent<EnemyBehaviour>().score)
            {
                enemyRef.currentState = EnemyBehaviour.enemyState.Chase;

            }
            else if (enemyRef.score < collision.gameObject.GetComponent<EnemyBehaviour>().score)
            {
                // Or flee, if otherwise
                enemyRef.currentState = EnemyBehaviour.enemyState.Flee;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            enemyRef.currentState = EnemyBehaviour.enemyState.Wander;
        }
    }
}
