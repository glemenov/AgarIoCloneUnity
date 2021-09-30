using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    [SerializeField]
    // The bigger the player, the less is speed penalty;
    private float speed_penalty = 0.03f;

    // Scalling of the player
    private Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);

    void Start()
    {
        // Setting up the default color for player (Debug Purposes)
        //GameHandler.GH.player_color = Color.red;

        // Set the player color as the one chosen on the menu
        gameObject.GetComponent<SpriteRenderer>().color = GameHandler.GH.player_color;
    }

    void Update()
    {

        Vector3 pos = transform.position;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            // Movement
            Vector3 dir = hit.point - transform.position;
            pos += dir.normalized * (dir.magnitude * speed) * Time.deltaTime;

            // Player limitations
            pos.z = 0f;
            pos.x = Mathf.Clamp(pos.x, -45f, 45f);
            pos.y = Mathf.Clamp(pos.y, -45f, 45f);
        }

        transform.position = pos;
    }

    // Collision handler with enemies
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            if (GameHandler.GH.score > collision.gameObject.GetComponent<EnemyBehaviour>().score)
            {
                GameHandler.GH.score += collision.gameObject.GetComponent<EnemyBehaviour>().score;

                Destroy(collision.gameObject);

            } else if (GameHandler.GH.score < collision.gameObject.GetComponent<EnemyBehaviour>().score)
            {
                Destroy(gameObject);
                GameHandler.GH.gameOver.DeathScreen();
            }
        }

        if (collision.transform.tag == "Food")
        {
            Destroy(collision.gameObject);

            //Increasing the score and size of player
            GameHandler.GH.score++;
            gameObject.transform.localScale += scaleChange;

            if (speed > 0)
                speed -= speed_penalty;

            if (speed_penalty >= 0)
                speed_penalty -= 0.001f;

        }
    }
}
