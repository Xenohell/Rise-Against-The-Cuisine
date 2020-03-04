using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options_scene : MonoBehaviour
{
    public Scene scenes;
    // Start is called before the first frame update
    public void Scene_change()
    {
        SceneManager.LoadScene("Options");
    }
}
