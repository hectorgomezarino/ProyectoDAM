using UnityEngine;


public class AlienBullet : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    public float speed = 25; //change this for more alien bullet speed
    public Sprite explodedShipImage;


    // Use this for initialization
    void Start()
    {  //the same as bullet start section
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.down * speed;
    }

    void OnTriggerEnter2D(Collider2D col) //object colided
    {
        if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player") //allien colide with player, defeat
        {
            // Destroy AlienBullet
            Destroy(gameObject);
            CommonLibrary.Instance.GameDefeat(col);
        }

        if (col.tag == "Shield")
        {  //the same as bullet shield colider section
            Destroy(gameObject);
            Destroy(col.gameObject);
            CommonLibrary.Instance.ShieldsDamaged("Loosing shields by alien atack.", -2);
        }
    }


    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }

}
