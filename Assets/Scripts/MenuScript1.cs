using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript1 : MonoBehaviour
{
    public Button baslaButton;
    public Button c�k�sButton;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("se");
        transform.Find("BaslaButton").GetComponent<Button>().onClick.AddListener(Basla);
        transform.Find("C�k�s").GetComponent<Button>().onClick.AddListener(C�k);
        Debug.Log(PlayerPrefs.GetInt("score"));
        transform.Find("Score").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetInt("score").ToString();
        transform.Find("TopScore").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetInt("topscore").ToString();
    }

    void Basla()
    {
        Debug.Log("You have clicked the button!");
        MenuManager.Load(MenuManager.Scene.Demo_Scene);
    }

    public void C�k()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }


}
