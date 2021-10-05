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
    private Vector3 pos;

    // Logic
    public GameObject target;

    public enum enemyState
    {
        Wander, Chase, Flee
    }

    public enemyState currentState;

    void Start()
    {
        randomPos = new Vector3(Random.Range(-40f, 40f), Random.Range(-40f, 40f), 0f);
    }

    void Update()
    {
        pos = transform.position;
        // If there is no target around - Wander
        if (target == null)
        {
            ChangeState(enemyState.Wander);
        } 

        switch (currentState)
        {
            // Wandering to the random position on the map
            case enemyState.Wander:
            {
                    dir = randomPos - transform.position;

                    // Changing the random position if almost got to the original
                    if(dir.magnitude < 5)
                    {
                        randomPos = new Vector3(Random.Range(-40f, 40f), Random.Range(-40f, 40f), 0f);
                    }

                    break;
            }
            
            // Follow the selected target
            case enemyState.Chase:
            {
                    dir = target.transform.position - transform.position;
                    
                    // If following player, and suddenly player score is bigger - flee
                    if(target.tag == "Player")
                    {
                        if(score < GameHandler.GH.score)
                        {
                            ChangeState(enemyState.Flee);
                        }
                    }

                    break;
            }

            // Flee from the selected target
            case enemyState.Flee:
            {
                    dir = -(target.transform.position - transform.position);

                    // If following player, and suddenly enemy score is bigger - chase
                    if (target.tag == "Player")
                    {
                        if (score > GameHandler.GH.score)
                        {
                            ChangeState(enemyState.Chase);
                        }
                    }

                    break;
            }
        }

        Limitations();
        // Move every frame
        transform.position += dir.normalized * speed * Time.deltaTime;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with the food
        if (collision.transform.tag == "Food")
        {
            // Increasing score, destroying food obj., increasing in size and reducing speed.
            score++;
            Destroy(collision.gameObject);
            gameObject.transform.localScale += scaleChange;
            speed -= 0.02f;
        }

        // Collision with other enemy
        if (collision.transform.tag == "Enemy")
        {
            // Check if personal score is bigger or less compare to other enemy.
            if (score > collision.gameObject.GetComponent<EnemyBehaviour>().score)
            {
                // Destroy other enemy
                Destroy(collision.gameObject);
            }
            else if (score < collision.gameObject.GetComponent<EnemyBehaviour>().score)
            {
                // Destroy itself
                Destroy(gameObject);
            }
        }
    }

    public void ChangeState(enemyState _state)
    {
        currentState = _state;
    }

    private void Limitations()
    {
        // Enemy limitations
        pos.z = 0f;
        pos.x = Mathf.Clamp(pos.x, -40f, 40f);
        pos.y = Mathf.Clamp(pos.y, -40f, 40f);

        transform.position = pos;
    }
}
