using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreTimer;
    public float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        scoreTimer.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Math.Round(time,0).ToString();
    }

    public float currTime()
    {
        return time;
    }
}
