using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSC : MonoBehaviour
{
    public HealthSystem BombHealth;
    public GameObject AllBomb;
    public GameObject Expolation;
    float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        Expolation.gameObject.SetActive(false);
        BombHealth = new HealthSystem(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (BombHealth.GetHealth() <= 0)
        {
            
            if (timer >= 0)
            {
               
                timer -= Time.deltaTime;
            }
            else
            {
                
                AllBomb.gameObject.SetActive(false);
            }
        }
    }
   
    public void DecraseHealth(int amount)
    {
        BombHealth.Damage(amount);
        transform.Find("RedBombHealthBar").localScale = new Vector2((float)BombHealth.GetHealth() / 300, 0.0511f);
        if (BombHealth.GetHealth() <= 0)
        {
        
           Expolation.gameObject.SetActive(true);
          
        }
    }
}
