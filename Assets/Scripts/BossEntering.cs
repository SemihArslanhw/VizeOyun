using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEntering : MonoBehaviour
{

    public GameObject door;
    public GameObject player;
    public HealthSystem playerHealth;
    public GameObject healthBar;
    public GameObject shield;
    public GameObject Boss;

    public GameObject audioManager;

    public Button Qskill;
    public Button Eskill;
    public Button Rskill;


    private bool isQinCoolDown = false;
    private bool isEinCoolDown = false;
    private bool isRinCoolDown = false;
    private bool isShieldActive = false;
    private float shieldActiveTime = 3;
    private float qCoolDown = 7;
    private float eCoolDown = 9;
    private float rCoolDown = 10;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        door.SetActive(false);
        playerHealth = new HealthSystem(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q") && !isQinCoolDown)
        {
            shield.SetActive(true);
            isShieldActive = true;
            isQinCoolDown = true;
            playerHealth.OpenShield();
            qCoolDown = 7;
            shieldActiveTime = 3;
        }
        else if(isQinCoolDown)
        {
            if(qCoolDown < 0)
            {
                isQinCoolDown = false;
                Qskill.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Q";
                
            }
            else
            {
                qCoolDown -= Time.deltaTime;
                Qskill.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Math.Round(qCoolDown,0).ToString();
            }
            if(shieldActiveTime < 0 && isShieldActive)
            {
                isShieldActive = false;
                playerHealth.CloseShield();
                shield.SetActive(false);
               
                
            }
            else if(isShieldActive)
            {
               shieldActiveTime -= Time.deltaTime;
            }  
        }
        if (Input.GetKey("e") && !isEinCoolDown)
        {
           
            isEinCoolDown = true;
            playerHealth.Heal(20);
            SpriteRenderer healtSprite = healthBar.GetComponent<SpriteRenderer>();
            transform.Find("PlayerHealth").localScale = new Vector2((float)playerHealth.GetHealth() / 700, 0.0511f);
            eCoolDown = 9;
        }
        else if (isEinCoolDown)
        {
            if (eCoolDown < 0)
            {
                isEinCoolDown = false;
                Eskill.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "E";
            }
            else
            {
                Eskill.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Math.Round(eCoolDown, 0).ToString();
                eCoolDown -= Time.deltaTime;
            }
        }
        if(Input.GetKey("r") && !isRinCoolDown)
        {
            rCoolDown = 10;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePos - player.transform.position;
            float angle = Vector2.SignedAngle(Vector2.right, direction);
            isRinCoolDown = true;
            transform.position = new Vector3(angle - 3, angle - 3, transform.position.z);
        }
        else if (isRinCoolDown)
        {
            if(rCoolDown < 0)
            {
                isRinCoolDown = false;
                Rskill.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "R";
            }
            else
            {
                Rskill.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Math.Round(rCoolDown, 0).ToString();
                rCoolDown -= Time.deltaTime;
            }
        }
    }

    public void FixedUpdate()
    {
        if (playerHealth.GetHealth() <= 0)
        {
            player.SetActive(false);
        }
    }

    public void decrasePlayerHealth(int amount)
    {
        playerHealth.Damage(amount);
        transform.Find("PlayerHealth").localScale = new Vector2((float)playerHealth.GetHealth() / 700, 0.0511f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "CircleTrigger")
        {
            
            playerHealth.Damage(10);
            Debug.Log(playerHealth.GetHealth());
            
            transform.Find("PlayerHealth").localScale = new Vector2((float)playerHealth.GetHealth()/700,0.0511f);
        }

        if(collision.gameObject.name == "BossTriger") {
        door.SetActive(true);
        transform.position = new Vector3(player.transform.position.x , player.transform.position.y - 1, transform.position.z);
        Camera.main.orthographicSize = 1.5f;
        Boss.GetComponent<Boss>().start();
            audioManager.GetComponent<SCAudioManager>().BossMusicStart();
        }
        
    }
}
