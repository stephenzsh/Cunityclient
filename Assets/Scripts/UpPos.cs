﻿using Protobuf;
using UnityEngine;

public class UpPos:MonoBehaviour
{
    public UpPosRequest upPosRequest;

    private void Start()
    {
        upPosRequest= GetComponent<UpPosRequest>();
        InvokeRepeating("UpPosFun",1,1f/60f );
    }
    private void UpPosFun() {
        Vector2 pos = transform.position;
        Vector3 scale = transform.localScale;
        AnimatorPack animatorPack = new AnimatorPack();
        Animator animator = transform.GetComponent<Animator>();
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            // 找到名为isWalking的bool参数
            if (parameter.name == "isWalking" && parameter.type == AnimatorControllerParameterType.Bool)
            {
                // 获取参数的值
                animatorPack.IsWalking = animator.GetBool(parameter.nameHash);
            }
            if (parameter.name == "isGrounded" && parameter.type == AnimatorControllerParameterType.Bool)
            {
                // 获取参数的值
                animatorPack.IsGrounded = animator.GetBool(parameter.nameHash);
            }
            if (parameter.name == "attack" && parameter.type == AnimatorControllerParameterType.Trigger)
            {
                animatorPack.Attack = animator.GetBool(parameter.nameHash);
            }
            if (parameter.name == "hit" && parameter.type == AnimatorControllerParameterType.Trigger)
            {
                animatorPack.Hit = animator.GetBool(parameter.nameHash);
            }
        }
        upPosRequest.SendRequest(pos,scale,animatorPack);
    }
}

