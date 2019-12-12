using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ammo_count : MonoBehaviour
{
    public int p_loaded_ammo;
    public int p_max_ammo;
    public Text p_t_Ammo_count;
    // Start is called before the first frame update
    void Start()
    {
        p_loaded_ammo = p_max_ammo;
        p_max_ammo = 50;
        p_t_Ammo_count.text = "" + p_loaded_ammo + "/" + p_max_ammo;


    }

    // Update is called once per frame
    void Update()
    {
        p_t_Ammo_count.text = "" + p_loaded_ammo + "/" + p_max_ammo;
        if (Input.GetButtonDown("Fire1"))
        {
            p_loaded_ammo = p_loaded_ammo - 1;
        }

        if(p_loaded_ammo < 0)
        {
            p_loaded_ammo = p_max_ammo;
        }
    }
}
