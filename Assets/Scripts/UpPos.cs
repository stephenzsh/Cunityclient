using UnityEngine;

public class UpPos:MonoBehaviour
{
    public UpPosRequest upPosRequest;

    private void Start()
    {
        upPosRequest= GetComponent<UpPosRequest>();
        InvokeRepeating("UpPosFun",1,1f/30f );
    }
    private void UpPosFun() {
        Vector2 pos = transform.position;
        upPosRequest.SendRequest(pos);
    }
}

