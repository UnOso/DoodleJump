using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPos = new Transform[2];
    public GameObject platform;
    public float distanceToSpawn = 3.0f;
    private float distanceTravelled;

    // Start is called before the first frame update
    void Start()
    {
        distanceTravelled = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= distanceTravelled + distanceToSpawn)
            Spawn(transform.position.y);
    }

    private void Spawn(float yPos)
    {
        Instantiate(platform, new Vector2(spawnPos[pickNumber()].position.x, spawnPos[0].position.y), Quaternion.identity);
        distanceTravelled = transform.position.y;
    }

    private int pickNumber()
    {
        return Mathf.Clamp(Random.Range(-1, 3), 0, 2);
    }
}
