using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; set; }
    public Text scoreText;
    public GameObject[] enemyPrefabs; // An array of enemy prefabs to spawn
    public GameObject player;

    public float spawnInterval = 2.0f; // The time interval between each spawn
    public int maxEnemies = 50; // The maximum number of enemies that can be spawned at once


    private List<GameObject> enemies = new List<GameObject>(); // A list to keep track of all spawned enemies
    public int score {get; set; }


    // Start is called before the first frame update
    void Start()
    {
        // Set the initial value of the score and update the UI Text element with the initial score value
        score = 1;
        scoreText.text = "Score: " + score.ToString();
        // Set the position of the Enemy Spawner to be at the top right of the screen relative to the player
        Vector3 playerPos = player.transform.position;
        Vector3 viewportPos = new Vector3(1, 1, Camera.main.transform.position.z);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);
        transform.position = new Vector3(worldPos.x - (worldPos.x - playerPos.x) * 0.1f, worldPos.y - (worldPos.y - playerPos.y) * 0.1f, transform.position.z);
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn enemies
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Check if the maximum number of enemies has been reached
            if (enemies.Count < maxEnemies)
            {
                // Spawn a new enemy and add it to the list
                GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                GameObject newEnemy = Instantiate(randomEnemyPrefab, transform.position, Quaternion.identity);

                enemies.Add(newEnemy);
            }

            // Wait for the specified time interval before spawning another enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Function to remove a dead enemy from the list
    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);

    }

  
    public void addPoint()
    {
        // Increment the score by 1 and update the UI Text element with the new score value
        score++;
        scoreText.text = "Score: " + score.ToString();
    }




    void Update()
    {
        // Update the position of the Enemy Spawner to be at the top right of the screen relative to the player
        Vector3 playerPos = player.transform.position;
        Vector3 viewportPos = new Vector3(1, 1, Camera.main.transform.position.z);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);
        transform.position = new Vector3(worldPos.x - (worldPos.x - playerPos.x) * 0.1f, worldPos.y - (worldPos.y - playerPos.y) * 0.1f, transform.position.z);
    }

}
