using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //일정한 속도 이상으로 충돌했을때만 사운드 플레이
        if(collision.relativeVelocity.magnitude > 0.5f)
        {
            //부딛히는 소리 play
            AudioManager.instance.Play("DoorBang2");
        }
    }
}
