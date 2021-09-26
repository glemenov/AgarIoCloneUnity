using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Parameters
    private float speed = 2f;
    public int score;

    // Movement
    private Vector3 randomPos;
    private Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 dir;

    // Logic
    public GameObject target;
    public enum enemyState
    {
        Wander, Chase, Flee
    }

    private enemyState currentState;

    void Start()
    {
        // TODO: FIX IT, SO IT WOULD BE RANDOM EVERY CALL
        randomPos = new Vector3(Random.Range(-40f, 40f), Random.Range(-40f, 40f), 0f);
    }

    void Update()
    {
        if (target == null)
        {
            ChangeState(enemyState.Wander);
        }

        if (target != null)
        {
            ChangeState(enemyState.Chase);
        }

        switch (currentState)
        {
            case enemyState.Wander:
            {
                    dir = randomPos - transform.position;
                    break;
            }
            case enemyState.Chase:
            {
                    dir = target.transform.position - transform.position;
                    break;
            }
        }

        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Food")
        {
            score++;
            Destroy(collision.gameObject);

            gameObject.transform.localScale += scaleChange;
            speed -= 0.02f;
        }
    }

    public void ChangeState(enemyState _state)
    {
        currentState = _state;
    }
}
