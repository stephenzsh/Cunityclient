using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRequest : MonoBehaviour
{

    protected GameFace face = GameFace.Face;

    //�Ӹ�enum type,���ֲ�ͬ����

    public virtual void Awake()
    {
        face.AddRequest(this);
    }

    
}
