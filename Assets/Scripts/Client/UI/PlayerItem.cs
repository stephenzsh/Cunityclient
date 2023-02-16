using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem :MonoBehaviour
{

    [SerializeField]
    private Text playername;

    [SerializeField]
    private Slider slider;

    public void Set(string str,int v)
    {
        playername.text = str;
        slider.value = v;
    }

    public void Up(int v)
    {
        slider.value = v;
    }
    
}