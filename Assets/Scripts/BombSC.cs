using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSC : MonoBehaviour
{
    public HealthSystem BombHealth;
    public GameObject AllBomb;
 
    // Start is called before the first frame update
    void Start()
    {
        BombHealth = new HealthSystem(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void DecraseHealth(int amount)
    {
        BombHealth.Damage(amount);
        transform.Find("RedBombHealthBar").localScale = new Vector2((float)BombHealth.GetHealth() / 300, 0.0511f);
        if (BombHealth.GetHealth() <= 0)
        {
            AllBomb.gameObject.SetActive(false);
        }
    }
}
