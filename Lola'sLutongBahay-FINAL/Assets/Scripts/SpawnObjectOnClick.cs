using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnClick : MonoBehaviour
{
    public GameObject objectToSpawn; // The game object to spawn
    public Vector2 spawnPosition; // The position to spawn the object

    private void OnMouseDown()
    {
        // Check if the object to spawn is assigned
        if (objectToSpawn != null)
        {
            // Calculate the spawn position based on the input values
            Vector3 position = new Vector3(spawnPosition.x, spawnPosition.y, 0f);

            // Instantiate the object at the specified spawn position
            Instantiate(objectToSpawn, position, Quaternion.identity);
        }
    }
}



