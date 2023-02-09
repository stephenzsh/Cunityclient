using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserItem : MonoBehaviour
{
    [SerializeField]
    private Text playername;
   
    public void SetPlayerName(string name)
    {
        playername.text = name;
    }
}
