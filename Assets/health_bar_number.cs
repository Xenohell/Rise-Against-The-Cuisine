using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar_number : MonoBehaviour
{
    public Text p_health_Text;
    public Slider p_health_bar_slider;
    public float p_current_health;
    public float p_max_health;
    public GameObject testbox;
    void Start()
    {
        p_current_health = p_max_health;
        p_health_bar_slider.value = ChangeHealth();


    }
    
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        p_health_bar_slider.value = ChangeHealth();
        p_health_Text.text = "" + (Mathf.Round(p_current_health)) + "%";

        if(p_current_health <= 0)
        {
            Destroy(testbox);
        }
    }
    float ChangeHealth()
    {

        return p_current_health / p_max_health;
    }
}
        