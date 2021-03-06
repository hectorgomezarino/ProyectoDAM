﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceShipPlayer : MonoBehaviour
{

    public float speed = 3; //the default speed of the player ship
    public GameObject theBullet;

    float lastStep;
    public float timeBetweenSteps = 0.5f;//for delay the player shoot. I recomend between 0.2 to 2. Public to set it into player object

    void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");
        //GetComponent<RigidBody 2D>().velocity = new Vector2 (horzMove, 0 ) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time; //delay the player shot.
                //int FirePosition = transform.position + 5;
                //hga TO DO: usar una posición más elevada para crear el disparo
                Instantiate(theBullet, transform.position, Quaternion.identity);
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.bulletFire);
            }
        }
        CommonLibrary.Instance.ModifyTextAlienCountUIScore(); // call once per frame count alien
        CommonLibrary.Instance.CountShields(); // call once per frame count alien
    }
}
