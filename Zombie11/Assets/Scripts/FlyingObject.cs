using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //������ �ӵ� �̻����� �浹�������� ���� �÷���
        if(collision.relativeVelocity.magnitude > 0.5f)
        {
            //�ε����� �Ҹ� play
            AudioManager.instance.Play("DoorBang2");
        }
    }
}
