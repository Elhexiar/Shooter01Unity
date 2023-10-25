using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieManager : MonoBehaviour
{
    public GameObject hexEnnemiepref;
    public float spawnOffset;
    public int clock = 0;
    public int timeLimit;
    private int itteration = 0;

    // Start is called before the first frame update

    void spawnWave(GameObject ennemie)
    {

        for (int i = 1; i < 4; i++)
        {
            GameObject spawnedEnnemie = Instantiate(ennemie, transform.localPosition + Vector3.left *spawnOffset* i, transform.localRotation);

            spawnedEnnemie.GetComponent<EnnemieFall>().dephasage = itteration;

            spawnedEnnemie = Instantiate(ennemie, transform.localPosition + Vector3.right * spawnOffset * i, transform.localRotation);

            spawnedEnnemie.GetComponent<EnnemieFall>().dephasage = itteration;
        }
        

    }
    void Start()
    {
        clock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        clock++;
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            spawnWave(hexEnnemiepref);
            
        }

        if(clock%timeLimit == 0) { spawnWave(hexEnnemiepref); clock = 0; itteration++; }
    }
}
