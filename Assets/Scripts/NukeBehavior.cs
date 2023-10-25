using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeBehavior : MonoBehaviour
{


    public PlayerScript myPlayer;
    public float ExpansionRate;
    // Start is called before the first frame update
    void Start()
    {
        ExpansionRate = myPlayer.nukeExpansionRate;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale *= ExpansionRate;
        if(transform.localScale.x > 50 ) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("coucou");  
        if (collision.gameObject.tag == "Triangle")
        {
            Destroy(collision.gameObject);
            //GameObject createdPowerUp = Instantiate(powerUp, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "powerUp")
        {
            myPlayer.Score += 10;
            Destroy(collision.gameObject);
            //Destroy(gameObject);
        }

    }
}
