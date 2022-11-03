using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPoint;
    public GameObject player;
    public float bulletSpeed = 100;
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = player.GetComponent<Rigidbody2D>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            
        }
    }
    public void shoot()
    {
       Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - player.transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 positionBullet = gunPoint.GetComponent<Transform>().position;
        Quaternion rotationBullet = Quaternion.Euler(0, 0, bullet.transform.eulerAngles.z + angle);
        
        GameObject bulletClone = Instantiate(bullet , positionBullet , rotationBullet );
        bulletClone.GetComponent<BulletSpeed>().shoot(angle);

        
        
    }
}
