using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] platSpawnPos = new Transform[2];
    public GameObject platform;
    public float distanceToSpawnPlatform = 3.0f;
    private float distanceTravelled;

    // Start is called before the first frame update
    void Start()
    {
        distanceTravelled = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= distanceTravelled + distanceToSpawnPlatform)
            SpawnPlatform(transform.position.y);
    }

    private void SpawnPlatform(float yPos)
    {
        Instantiate(platform, new Vector2(platSpawnPos[pickNumber()].position.x, platSpawnPos[0].position.y), Quaternion.identity);
        distanceTravelled = transform.position.y;
    }

    private int pickNumber()
    {
        return Mathf.Clamp(Random.Range(-1, 3), 0, 2);
    }
}
