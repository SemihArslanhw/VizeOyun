using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{

    public GameObject RedBomb;
    public GameObject Boss;
    
    private float bulletSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot(float angle)
    {
        Vector2 dir = new Vector2(bulletSpeed * Mathf.Cos(angle * Mathf.PI / 180), bulletSpeed * Mathf.Sin(Mathf.PI / 180 * angle));
        this.GetComponent<Rigidbody2D>().velocity = dir;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.name != "Sniper")
        {
            this.gameObject.SetActive(false);
        }
        if(collision.collider.name == "RedBomb")
        {
            RedBomb.GetComponent<BombSC>().DecraseHealth(10);
        }
        if(collision.collider.name == "MaceRed")
        {
            Boss.GetComponent<Boss>().DecraseHealth(50);
        }
    }
}
