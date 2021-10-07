using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.1f;
    private Vector3 offset;
    private float highestPos;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target.position.y > highestPos)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x, target.position.y + offset.y, transform.position.z), smoothing);
            highestPos = transform.position.y;
        }
    }
}
