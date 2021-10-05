using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject food_prefab;
    
    void Start()
    {
        GameHandler.GH.audioMan.Play("Game");
        GameHandler.GH.food = 2000;
        Spawn(GameHandler.GH.food);
    }

    // Spawning a number of enemies
    void Spawn(int _amount)
    {
        for(int i = 0; i < _amount; i++)
        {
            // Random location on the plane (Size of plane is 50, 50)
            float xVal = Random.Range(-40, 40);
            float yVal = Random.Range(-40, 40);

            // Position and rotation
            Vector3 pos = new Vector3(xVal, yVal, 0f);
            Quaternion rot = Quaternion.Euler(0f, 0f, 0f);

            // Spawning
            var obj = Instantiate(food_prefab, pos, rot);
        }
    }
}
