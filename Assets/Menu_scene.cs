using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_scene : MonoBehaviour
{
    public string level;

    public void PlayGame()
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
