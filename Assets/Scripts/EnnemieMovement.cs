using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float amplitude = 0.001f;
    public float speed = 0.05f;
    private Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = spawnPoint + new Vector3(Mathf.Sin(Time.time*speed) * amplitude, 0, 0);
    }
}
