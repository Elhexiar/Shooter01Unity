using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public GameObject powerUp;
    public Transform parent;
    public PlayerScript myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Triangle")
        {
            GameObject createdPowerUp = Instantiate(powerUp, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            
            
        }
        

        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "powerUp")
        {
            myPlayer.Score += 10;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if (collision.gameObject.tag == "Tier2")
            {
                myPlayer.streak++;
                if (myPlayer.streak >= myPlayer.streakLimit)
                {
                    GameObject createdPowerUp = Instantiate(powerUp, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                    myPlayer.streak = 0;
                }
            }
        }
        

    }

}
