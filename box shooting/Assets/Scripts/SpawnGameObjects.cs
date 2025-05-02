using UnityEngine;

public class SpawnGameObjects : MonoBehaviour
{
    public float xMinRange = -25.0f;
    public float xMaxRange = 25.0f;
    public float yMinRange = 8.0f;
    public float yMaxRange = 25.0f;
    public float zMinRange = -25.0f;
    public float zMaxRange = 25.0f;
    public GameObject[] spawnObjects; // what prefabs to spawn

    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, 1.0f);
    }

    void Spawn()
    {
        if (GameManager.gm.gameIsOver)
            return;
        Vector3 spanwPosition;
        // get a random position in the world
        spanwPosition.x = Random.Range(xMinRange, xMaxRange);
        spanwPosition.y = Random.Range(yMinRange, yMaxRange);
        spanwPosition.z = Random.Range(zMinRange, zMaxRange);
        float r1 = Random.Range(0.0f, 360.0f),
            r2 = Random.Range(0.0f, 360.0f),
            r3 = Random.Range(0.0f, 360.0f);
        // get a random rotation
        Quaternion spawnRotation = Quaternion.Euler(r1, r2, r3);
        // get a random prefab to spawn
        int index = Random.Range(0, spawnObjects.Length);
        GameObject spawnObject = spawnObjects[index];
        // instantiate the prefab at the random position and rotation
        Instantiate(spawnObject, spanwPosition, spawnRotation);
    }
}
