using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainchar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Qskill").GetComponentInChildren<Text>().text = "Q";
        GameObject.Find("Wskill").GetComponentInChildren<Text>().text = "W";
        GameObject.Find("Rskill").GetComponentInChildren<Text>().text = "R";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
