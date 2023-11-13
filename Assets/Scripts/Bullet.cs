using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float speed;
    public GameObject powerUp;
    public Transform parent;
    public PlayerScript myPlayer;
    public Vector3 particleOffset;
    public ParticleSystem hitParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.velocity = Vector3.up*speed;
        
        
    }

    void SpawnParticle(Collision2D collidedObjectReference)
    {
        ParticleSystem current = Instantiate(hitParticleSystem, transform.position + particleOffset, transform.rotation);
        SpriteRenderer collidedObjectRenderer = collidedObjectReference.gameObject.GetComponent<SpriteRenderer>();
        current.startColor = collidedObjectRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Triangle")
        {
            GameObject createdPowerUp = Instantiate(powerUp, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            SpawnParticle(collision);


        }
        

        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "powerUp")
        {
            myPlayer.Score += 10;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SpawnParticle(collision);
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
