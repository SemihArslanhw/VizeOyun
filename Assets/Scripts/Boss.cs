using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public HealthSystem BossHealth;
    public GameObject TheEnd;
    public GameObject BossBullet;
    public GameObject BulletSpawnPoint;
    public GameObject audioManager;
    public GameObject Timerr;
    Vector3 positionBullet;
    private float timer = 1f;
    
    private bool isStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        BossHealth = new HealthSystem(100);
        positionBullet = BulletSpawnPoint.GetComponent<Transform>().position;
        TheEnd.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (isStarted)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 1;
                Quaternion rotationBullet = Quaternion.identity;
                GameObject BulletClone = Instantiate(BossBullet, positionBullet, rotationBullet);
                BulletClone.GetComponent<BombBulletSpeed>().shoot();
            }

        }
    }

    public void start()
    {
        this.isStarted = true;
    }

    public void DecraseHealth(int amount)
    {
        BossHealth.Damage(amount);
        transform.Find("BossHealthBar").localScale = new Vector2((float)BossHealth.GetHealth() / 20, transform.Find("BossHealthBar").localScale.y);
        if (BossHealth.GetHealth() <= 0)
        {
            this.gameObject.SetActive(false);
            TheEnd.gameObject.SetActive(true);
            audioManager.GetComponent<SCAudioManager>().BossKilledMusic();
            Debug.Log(Timerr.GetComponent<ScoreManager>().currTime());
            PlayerPrefs.SetInt("score",1000 - (int)Timerr.GetComponent<ScoreManager>().currTime());
            float topScore = PlayerPrefs.GetInt("topscore");
            if(topScore < 1000 - (int)Timerr.GetComponent<ScoreManager>().currTime())
            {
                PlayerPrefs.SetInt("topscore", 1000 - (int)Timerr.GetComponent<ScoreManager>().currTime());
            }
        }
    }
}
