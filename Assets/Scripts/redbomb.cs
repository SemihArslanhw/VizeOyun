using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBomb : MonoBehaviour
{
    public HealthSystem RedBombHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
    }
}
