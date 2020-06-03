using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Alien : MonoBehaviour
{

    public float speed = 50;

    public Rigidbody2D rigidBody;

    // Starting sprite
    public Sprite startingImage;

    // Alternative image used for the Alien
    public Sprite altImage;

    // Used to change the Alien image
    private SpriteRenderer spriteRenderer;

    // Wait time before switching sprites
    public float secBeforeSpriteChange = 0.5f;

    // Reference to bullet GameObject
    public GameObject alienBullet;

    // Minimum time to wait before firing
    public float minFireRateTime = 0.5f; //antes era: 1.0f, demasiado rápido.

    // Maximum time to wait before firing
    public float maxFireRateTime = 2f; //antes era: 3.0f, demasiado rápido.

    // Base firing wait time
    public float baseFireWaitTime = 1.2f;

    Coroutine alienRoutine;

    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();

        // Set the starting direction and speed
        rigidBody.velocity = new Vector2(1, 0) * speed;

        // Access the SpriteRenderer component
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        // Call changeAlienSprite () to cycle the Alien sprites
        // start the coroutine the usual way but store the Coroutine object that StartCoroutine returns.
        alienRoutine = StartCoroutine(changeAlienSprite()); // start the coroutine

        // Defines a random fire wait time for each Alien
        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

    }

    // Changes the direction for the Alien object
    void Turn(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }

    // Moves the Alien vertically down
    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 10; //el alien baja esos px.
        transform.position = position;
    }


    // Switch direction on collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "VertWallLeft")
        {
            Turn(1);
            MoveDown();
        }
        if (col.gameObject.name == "VertWallRigth")
        {
            Turn(-1);
            MoveDown();
        }
        if (col.gameObject.tag == "Bullet")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            Destroy(gameObject);
        }
        if (col.gameObject.name == "HorzWallFloor" || col.gameObject.tag == "Player") //alien landing OR allien colide with player: defeat
        {
            var player = GameObject.Find("SpaceShip").GetComponent<Collider2D>(); //get the player colider for GameDefeat method
            CommonLibrary.Instance.GameDefeat(player);
            StopCoroutine(alienRoutine); // stop the coroutine //stop alien coroutine //TO DO: this must be into GameDefeat
        }
    }

    // Used to change the current sprite and play sounds
    public IEnumerator changeAlienSprite()
    {
        while (true)
        { //TO DO: bug detected, when alien is destroyed the new sprite by movement appears one second
            if (spriteRenderer.sprite == startingImage)
            {
                spriteRenderer.sprite = altImage;
                if (SoundManager.Instance) //added by crash
                {
                    SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienBuzz1);
                }
            }
            else
            {
                spriteRenderer.sprite = startingImage;
                if (SoundManager.Instance) //added by crash
                {
                    SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienBuzz2);
                }
            }
            yield return new WaitForSeconds(secBeforeSpriteChange);
        }
    }

    // Have Aliens fire bullets (Ammo) at random times
    void FixedUpdate()
    {
        if (Time.time > baseFireWaitTime)
        {
            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime); //generate next time
            Instantiate(alienBullet, transform.position, Quaternion.identity); //create alienBullet
        }
    }

    /*
     *  TO DO: remove this??? hga '?', no veo si tiene sentido gestionar colisión entre alien y jugador.
     */
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") //allien colide with player: defeat
        {
            // Destroy AlienBullet
            //Destroy(gameObject); //remove it?
            var player = GameObject.Find("SpaceShip").GetComponent<Collider2D>(); //get the player colider for GameDefeat method
            CommonLibrary.Instance.GameDefeat(player);
            //CommonLibrary.Instance.GameDefeat(col);
        }
    }
}