using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class health_bar_number : MonoBehaviour
{
    public TextMeshProUGUI p_health_Text; //this is the text of the health
    public TextMeshProUGUI GameOverText; // this is the game over text

    public Slider p_health_bar_slider; // the healthbar slider only works between 1 and 0 so works as decimal values
    public float p_current_health; //this is the current health
    public float p_max_health; // max health. current health cant go over max health unless changed outside of game
    public GameObject testbox; // to be changed to player

    public bool GameOverBool = false; // and its a boolean for when you die the game isnt over
    void Start()
    {
        p_current_health = p_max_health; //on start current health = max health
        p_health_bar_slider.value = ChangeHealth(); //the health bar slider value is what the change health says


    }

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        p_health_bar_slider.value = ChangeHealth(); //slider value is what change health says
        p_health_Text.text = "" + (Mathf.Round(p_current_health)) + "%"; // the health bar text is a rounded up version of 
        if (p_current_health >= 1)
        {
            GameOverText.text = " ";
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

        return p_current_health / p_max_health; //your health is = to current health/ max health as it needs to work as a percentage for the slider
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
