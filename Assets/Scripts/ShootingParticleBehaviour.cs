using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShootingParticleBehaviour : MonoBehaviour
{
    public int timer = 0;
    public int limit = 60;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if(timer >= limit)
        {
            Destroy(gameObject);
        }
    }
}
