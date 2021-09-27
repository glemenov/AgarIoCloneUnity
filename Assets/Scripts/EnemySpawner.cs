using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy_prefab;

    void Start()
    {
        Spawn(30);
    }

    void Spawn(int _amount)
    {
        for (int i = 0; i < _amount; i++)
        {
            // Random location on the plane (Size of plane is 50, 50)
            float xVal = Random.Range(-40, 40);
            float yVal = Random.Range(-40, 40);

            // Position and rotation
            Vector3 pos = new Vector3(xVal, yVal, 0f);
            Quaternion rot = Quaternion.Euler(0f, 0f, 0f);

            // Spawning
            var obj = Instantiate(enemy_prefab, pos, rot);
        }
    }
}
