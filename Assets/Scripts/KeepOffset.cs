using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOffset : MonoBehaviour
{
    public Transform target;
    public bool keepOffsetX;
    public bool keepOffsetY;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (keepOffsetX)
            transform.position = new Vector2(target.position.x + offset.x, transform.position.y);
        if (keepOffsetY)
            transform.position = new Vector2(transform.position.x, target.position.y + offset.y);
    }
}
