using Google.Protobuf.Collections;
using Protobuf;
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager :BaseManager
{
    public PlayerManager(GameFace face) : base(face) { }
   
    public GameObject character;
    
    private Transform spwanPos; 
    
    Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();
    
    public override void OnInit()
    {
        base.OnInit();
        character =Resources.Load("Prefab/Player")as GameObject;
        
    }
   
   
    public void addPlayer(List<Player> pack)
    {
        
        foreach (var p in pack) 
        {
            
            GameObject g= GameObject.Instantiate(character, new Vector3(p.Pos.PosX, p.Pos.PosY), Quaternion.identity);
            if (p.Name.Equals(face.UserName))
            {
                //创建本地角色       
                g.AddComponent<UpPosRequest>();
                g.AddComponent<UpPos>();
                g.GetComponent<PlayerController>().isLocalPlayer = true;
               
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

    public void GameExit()
    {
        foreach (var VARIABLE in players.Values)
        {
            GameObject.Destroy(VARIABLE);
        }
        players.Clear();
    }
    public void UpPos(GameMessage gameMessage)
    {
        foreach (var Player in gameMessage.Players)
        {
            if (Player.Name == face.UserName)  
                continue;
            PosPack posPack = Player.Pos;
            if (players.TryGetValue(Player.Name, out GameObject g))
            {
                Vector2 pos = new Vector2(posPack.PosX, posPack.PosY);
                //float CharacterRot = posPack.RotZ;
                g.transform.position = pos;
            }
        }
        
    }
}