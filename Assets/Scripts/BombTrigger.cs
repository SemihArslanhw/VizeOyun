using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    public GameObject RedBomb;
    public GameObject BlackBomb;
    public GameObject CircleTrigger;
    public GameObject BombObj;
    public GameObject BombExplotion;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        RedBomb.SetActive(false);
        BombExplotion.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Sniper")
        {
        RedBomb.SetActive(true);
        BlackBomb.SetActive(false);
       
        }
        
    }
}
