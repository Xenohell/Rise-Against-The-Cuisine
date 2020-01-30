using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar_number : MonoBehaviour
{
    public Text p_health_Text;
    public Text GameOverText;
    public Slider p_health_bar_slider;
    public float p_current_health;
    public float p_max_health;
    public GameObject testbox;
    public bool GameOverBool = false;
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
        if (p_current_health >= 1)
        {
            GameOverText.text = "";
        }

        if (p_current_health <= 0 && !GameOverBool)
        {
            GameOverBool = true;
            Destroy(testbox);
            GameOver();
        }
    }
    float ChangeHealth()
    {

        return p_current_health / p_max_health;
    }
    void GameOver()
    {
        if (GameOverBool == true)
        {
            string[] dead = new string[]
             {"You're Toast", "You're Swiss Cheese",
         "Roasted", "Consumed", "Smoked", "Sliced", "Diced",
         "You've been Fried", "Smoked Out",
         "Burned", "Someone's Cooking Tonignt",
         "You're cooked", "Consumed", "You're Someones Dinner Now",
         "Roasty Toasty"};
            GameOverText.text = dead[Random.Range(0, dead.Length - 1)];
        }
    }
}
