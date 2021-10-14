using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    public Transform[] spawnPos = new Transform[2];
    public GameObject[] bg = new GameObject[1];
    public float distanceToSpawnBg = 4.5f;
    private float distanceTravelled = 0f;
    private float offset = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= distanceTravelled + distanceToSpawnBg)
            SpawnBg();
    }

    private void SpawnBg()
    {
        Instantiate(bg[0], new Vector2(spawnPos[0].position.x, spawnPos[0].position.y + offset), Quaternion.identity);
        Instantiate(bg[1], new Vector2(spawnPos[1].position.x, spawnPos[1].position.y + offset), Quaternion.identity);
        distanceTravelled = Mathf.Round(transform.position.y * 10)/10;
    }
}
