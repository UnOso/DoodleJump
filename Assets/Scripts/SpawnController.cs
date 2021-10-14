using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject platform;
    public float distanceToSpawn = 3.0f;
    private float distanceToTravel;

    // Start is called before the first frame update
    void Start()
    {
        distanceToTravel = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= distanceToTravel + distanceToSpawn)
            Spawn(transform.position.y);
    }

    private void Spawn(float yPos)
    {
        Instantiate(platform, new Vector2(0.0f, yPos), Quaternion.identity);
    }
}
