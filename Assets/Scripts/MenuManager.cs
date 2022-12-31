using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager 
{
   
    public enum Scene
    {
        Demo_Scene,
        Loading,
        menu
    }
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(Scene.Loading.ToString());

        SceneManager.LoadScene(scene.ToString());
    }
    public static void UnLoad(Scene scene)
    {
        SceneManager.UnloadSceneAsync(scene.ToString());
    }
}
