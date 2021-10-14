using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    public Transform[] spawnPos = new Transform[2];
    public GameObject[] bg = new GameObject[1];
    public float distanceToSpawnBg = 3.0f;
    private float distanceTravelled;

    // Start is called before the first frame update
    void Start()
    {
        distanceTravelled = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= distanceTravelled + distanceToSpawnBg)
            SpawnPlatform(transform.position.y);
    }

    private void SpawnPlatform(float yPos)
    {
        Instantiate(bg[0], new Vector2(spawnPos[0].position.x, spawnPos[0].position.y), Quaternion.identity);
        Instantiate(bg[1], new Vector2(spawnPos[1].position.x, spawnPos[1].position.y), Quaternion.identity);
        distanceTravelled = transform.position.y;
    }
}
