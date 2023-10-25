using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieFall : MonoBehaviour
{
    public float fallingRate;
    public Vector3 spawnPoint;
    public float sineSpeed;
    public float amplitude;
    public float dephasage = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.down * fallingRate;
        transform.position = new Vector3(spawnPoint.x + Mathf.Sin(Time.time * sineSpeed + dephasage) * amplitude,transform.position.y -  fallingRate, 0);
    }
}
