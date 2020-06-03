using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBullet : MonoBehaviour
{

    public float speed = 30;
    private Rigidbody2D rigidBody;
    public Sprite explodedAlienImage;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col)//col is colisioned Unity Object
    {
        if (col.tag == "Wall") //when colide with wall
        {
            Destroy(gameObject);
        }

        if (col.tag == "Alien")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            CommonLibrary.Instance.ModifyTextUIScore(50); //add 100 points
            Destroy(gameObject);
            Destroy(col.gameObject, 0.1f);
            CommonLibrary.Instance.ModifyWinStateText("Alien Destroyed.");
        }

        if (col.tag == "Shield")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            CommonLibrary.Instance.ShieldsDamaged("Loosing shields by your atack.", -1);
        }
    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }

}
