using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_health_loss : MonoBehaviour
{

    void OnMouseDown()
    {
        Debug.Log("You have clicked the square");
        GetComponent<health_bar_number>();        
    }
}