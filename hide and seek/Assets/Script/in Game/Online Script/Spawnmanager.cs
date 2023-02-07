using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    // List of prefabs to be instantiated initially
    public List<GameObject> hiders;
    // List of prefabs to be instantiated after the delay
    public List<GameObject> Seekers;
    // Initial number of objects to spawn
    public int TotalHiders = 10;
    // Time to wait before spawning additional objects
    public float spawnDelay = 60f;
    // Number of additional objects to spawn
    public int TotalSeekers = 2;

    // Time since the start of the game
    private float timeSinceStart = 0f;
    // Number of remaining objects to spawn
    private int remainingSpawns = 0;
    // Flag to keep track of whether additional objects have been spawned
    private bool hasSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set the number of remaining objects to spawn
        remainingSpawns = TotalHiders;
        // Instantiate the initial objects
        for (int i = 0; i < TotalHiders; i++)
        {
            if (hiders.Count > 0)
            {
                // Select a random prefab from the list
                int prefabIndex = Random.Range(0, hiders.Count);
                GameObject prefab = hiders[prefabIndex];
                // Instantiate the prefab
                Instantiate(prefab, transform.position, transform.rotation);
            }
            else
            {
                // Break out of the loop if there are no more objects to spawn
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the time since the start of the game
        timeSinceStart += Time.deltaTime;

        // Check if the spawn delay has been reached and additional objects have not been spawned
        if (timeSinceStart >= spawnDelay && !hasSpawned)
        {
            // Set the flag to indicate that additional objects have been spawned
            hasSpawned = true;
            // Instantiate the additional objects
            for (int i = 0; i < TotalSeekers; i++)
            {
                if (Seekers.Count > 0)
                {
                    // Select a random prefab from the list
                    int prefabIndex = Random.Range(0, Seekers.Count);
                    GameObject prefab = Seekers[prefabIndex];
                    // Instantiate the prefab
                    Instantiate(prefab, transform.position, transform.rotation);
                }
                else
                {
                    // Break out of the loop if there are no more objects to spawn
                    break;
                }
            }
        }
    }
}
