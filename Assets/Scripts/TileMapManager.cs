using System;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
    public GameObject[] tilemapPrefabs; // Array to hold your tilemap prefabs
    public Transform player; // Player's transform

    private float nextInstantiateY; // The Y position to instantiate the next section
    private float tilemapHeight = 35f; // Height of the tilemap section
    private float renderOffset = 9f; // Units from the top of the tilemap to render the next one 
    private float tilesRendered = 0; // Track number of tiles rendered
    private void Start()
    {
        // Initialize the nextInstantiateY based on the player's starting Y position
        nextInstantiateY = (float)(Math.Ceiling(player.position.y) + 3f + tilemapHeight - renderOffset);
        Debug.Log("Start nextInstantiateY: " + nextInstantiateY);
    }

    private void Update()
    {
        // Check if the player is within 9 units from the top of the current tilemap section
        if (player.position.y > nextInstantiateY)
        {
            InstantiateNextSection();
            Debug.Log("Update nextInstantiateY: " + nextInstantiateY);
        }
    }

    private void InstantiateNextSection()
    {

        // Select a random prefab from the array
        GameObject prefabToInstantiate = tilemapPrefabs[UnityEngine.Random.Range(0, tilemapPrefabs.Length)];

        // Calculate the new Y position for the next section
        float instantiateY = nextInstantiateY + renderOffset;
        if (tilesRendered >= 1)
        {
            instantiateY += 6;
            nextInstantiateY += 6;
        }

        // Instantiate the new tilemap section at the calculated Y position
        Instantiate(prefabToInstantiate, new Vector3(0, instantiateY, 0), Quaternion.identity);
        tilesRendered++;
        
        // Update the nextInstantiateY for the next instantiation
        nextInstantiateY += tilemapHeight;

        // Debug to check the instantiation position
        Debug.Log("Instantiated Tilemap at Y: " + instantiateY);
        Debug.Log("Next nextInstantiateY: " + nextInstantiateY);
    }
}
