using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public int Score = 0;
    public float attackCooldownLimit = 50;
    public float attackCooldown = 0;
    public int level = 0;
    public float bulletSpawnOffset = 5;
    public GameObject nuke;
    public bool nukeReady = false;
    public float nukeExpansionRate = 1.01f;
    public TextMeshProUGUI ScoreUIRef;
    public TextMeshProUGUI nukeUIRef;
    public TextMeshProUGUI timerUIRef;
    public int streak = 0;
    public int streakLimit = 5;
    public ParticleSystem shootingParticleSystem;
    public float particleOffsett;
    private float timer= 0 ;



    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision player !!");
        if (collision.gameObject.tag == "powerUp")
        {
            print("LETSGO !!!");
            Destroy(collision.gameObject);
            level++;
            if(level == 1 || level == 3) { attackCooldownLimit *= 0.7f; }
            if (level == 2) { attackCooldownLimit *= 1.3f; }
            if(level == 3) { attackCooldown *= 0.7f; }
            if (level == 4) { nukeReady = true; }
            if (level > 4) { attackCooldownLimit *= 0.7f; nukeReady = true; }

        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        timerUIRef.text = timer.ToString("00.00");
        ScoreUIRef.text = "Score : " + Score;

        if (nukeReady) { nukeUIRef.text = "Nuke is ready : Press [F]"; }
        else nukeUIRef.text = "Nuke not available";


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left*speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right*speed;
        }
        if (Input.GetKey(KeyCode.Space) && attackCooldown == 0)
        {
            if(level >= 0 && level <= 1)
            {
                GameObject createdBullet = Instantiate(bullet, parent.position, parent.rotation);
                createdBullet.GetComponent<Bullet>().myPlayer = this;
                ParticleSystem mySecondParticleSystem = Instantiate(shootingParticleSystem, transform.position + Vector3.up * particleOffsett, Quaternion.Euler(-90, 0, 0));
            }
            if (level >= 2)
            {
                GameObject createdBulletLeft = Instantiate(bullet, parent.position + Vector3.left * bulletSpawnOffset, parent.rotation);
                createdBulletLeft.GetComponent<Bullet>().myPlayer = this;

                ParticleSystem myParticleSystem = Instantiate(shootingParticleSystem, transform.position + (Vector3.up * particleOffsett) + Vector3.left * bulletSpawnOffset, Quaternion.Euler(-90, 0, 0));
                ParticleSystem.ShapeModule myModuleSHape = shootingParticleSystem.shape;
                myModuleSHape.radius = 0.5f;


                GameObject createdBulletRight = Instantiate(bullet, parent.position + Vector3.right * bulletSpawnOffset, parent.rotation);
                createdBulletRight.GetComponent<Bullet>().myPlayer = this;
                ParticleSystem mySecondParticleSystem = Instantiate(shootingParticleSystem, transform.position + (Vector3.up * particleOffsett) + Vector3.right * bulletSpawnOffset, Quaternion.Euler(-90, 0, 0));
                

            }



            attackCooldown = attackCooldownLimit;
        }

        if (Input.GetKey(KeyCode.F) && nukeReady == true)
        {

            GameObject detonatedNuke = Instantiate (nuke, parent.position, parent.rotation);
            detonatedNuke.GetComponent<NukeBehavior>().myPlayer = this;
            nukeReady = false;
        }


        if (transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }

        
        if (attackCooldown > 0) { attackCooldown -= 1; } else { attackCooldown = 0; }

    }
}
