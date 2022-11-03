using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    public GameObject RedBomb;
    public GameObject BlackBomb;
    public GameObject CircleTrigger;
    public GameObject BombObj;
    public GameObject Player;
    public bool timerIsRunning = false;
    public float timeRemaining = 3;
    // Start is called before the first frame update
    void Start()
    {
        RedBomb.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
               
                timeRemaining = 0;
                timerIsRunning = false;
                float distance = Vector3.Distance(RedBomb.transform.position, Player.transform.position);
                Debug.Log(distance);
                if(distance < 1)
                {

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Sniper")
        {
        RedBomb.SetActive(true);
        BlackBomb.SetActive(false);
        timerIsRunning = true;
        }
        
    }
}
