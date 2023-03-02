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
    
   // private Transform spwanPos; 
    
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
                //g.AddComponent<UpStateMachine>();
                //g.AddComponent<UpState>();
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
            AnimatorPack animatorpack = Player.Animators;
            if (players.TryGetValue(Player.Name, out GameObject g))
            {
                Vector2 pos = new Vector2(posPack.PosX, posPack.PosY);
                g.transform.position = pos;
                Vector3 scale = new Vector3(posPack.ScaX,posPack.ScaY,0);
                g.transform.localScale = scale;
                Animator animator = g.GetComponent<Animator>();
                foreach (AnimatorControllerParameter parameter in animator.parameters)
                {
                    if (parameter.name == "isWalking" && parameter.type == AnimatorControllerParameterType.Bool)
                    {
                        animator.SetBool(parameter.nameHash, animatorpack.IsWalking);
                    }
                    if (parameter.name == "isGrounded" && parameter.type == AnimatorControllerParameterType.Bool)
                    {
                        animator.SetBool(parameter.nameHash, animatorpack.IsGrounded);
                    }
                    if (parameter.name == "attack" && parameter.type == AnimatorControllerParameterType.Trigger && animatorpack.Attack)
                    {
                        animator.SetTrigger(parameter.nameHash);
                    }
                    if (parameter.name == "hit" && parameter.type == AnimatorControllerParameterType.Trigger && animatorpack.Hit)
                    {
                        animator.SetTrigger(parameter.nameHash);
                    }
                }
            }
        }
    }
    public void UpState(GameMessage gameMessage)
    {

        foreach (var Player in gameMessage.Players)
        {
            if (Player.Name == face.UserName)
                continue;
            AnimatorPack animatorpack = Player.Animators;
            
            if (players.TryGetValue(Player.Name, out GameObject g))
            {
                Animator animator = g.GetComponent<Animator>();
                foreach (AnimatorControllerParameter parameter in animator.parameters)
                {
                    if (parameter.name == "isWalking" && parameter.type == AnimatorControllerParameterType.Bool)
                    {
                        animator.SetBool(parameter.nameHash, animatorpack.IsWalking);
                    }
                    if (parameter.name == "isGrounded" && parameter.type == AnimatorControllerParameterType.Bool)
                    {
                        animator.SetBool(parameter.nameHash, animatorpack.IsGrounded);
                    }
                    if (parameter.name == "attack" && parameter.type == AnimatorControllerParameterType.Trigger && animatorpack.Attack)
                    {
                        animator.SetTrigger(parameter.nameHash);
                    }
                    if (parameter.name == "hit" && parameter.type == AnimatorControllerParameterType.Trigger && animatorpack.Hit)
                    {
                        animator.SetTrigger(parameter.nameHash);
                    }
                }
            }
        }
    }
}