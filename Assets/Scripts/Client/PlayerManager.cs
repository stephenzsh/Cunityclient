using Google.Protobuf.Collections;
using Protobuf;
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager :BaseManager
{

    public GameObject character;
    private Transform spwanPos;
    public override void OnInit()
    {
        base.OnInit();
        character =Resources.Load("Prefab/Player")as GameObject;
        
    }
    public PlayerManager(GameFace face) : base(face) { }
    Dictionary<string,GameObject> players = new Dictionary<string, GameObject>();
   
    public void addPlayer(List<Player> pack)
    {
        spwanPos = GameObject.Find("SpawnPos").transform;
        foreach (var p in pack)
        {

            GameObject g; 
            
            if (p.Name.Equals(face.UserName))
            {
                //创建本地角色
                g = GameObject.Instantiate(character, spwanPos.position, Quaternion.identity);
                g.GetComponent<PlayerController>().isLocalPlayer = true;
                
                
            }
            else
            {
                g = GameObject.Instantiate(character, spwanPos.position, Quaternion.identity);
                g.GetComponent<PlayerController>().isLocalPlayer = false;
               
            } 
            
            players.Add(p.Name, g);
        }
    
        
    }
    public void RemovePlayer(string id)
    {
        if (players.TryGetValue(id, out GameObject g)){
            GameObject.Destroy(g);
            players.Remove(id);
        }else
        {
            Debug.Log("移除角色不存在");
        }
    }

   
    public override void OnDestroy()
    {
        base.OnDestroy();
       
    }
}