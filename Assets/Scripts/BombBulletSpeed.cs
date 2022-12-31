using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBulletSpeed : MonoBehaviour
{
    public GameObject Sniper;

    private float bulletSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        float rndmNmbr = Random.Range(-2000, 2000);
        rndmNmbr /= 100;
        Debug.Log(rndmNmbr);
        Vector2 dir = new Vector2(bulletSpeed * -1, bulletSpeed * Mathf.Sin(Mathf.PI / 180 * rndmNmbr));
        this.GetComponent<Rigidbody2D>().velocity = dir;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name != "MaceRed" )
        {
            Debug.Log(collision.collider.name);
            this.gameObject.SetActive(false);
        }
        if(collision.collider.name == "Sniper")
        {
            Sniper.GetComponent<BossEntering>().decrasePlayerHealth(20);
        }
    }
}
