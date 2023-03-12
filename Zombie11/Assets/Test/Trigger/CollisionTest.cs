using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Collision enter, stay, exit �̺�Ʈ �߻��Ҷ�
// �浹ü�� Player �϶� Debug.Log �̺�Ʈ �߻� ���
// Debug.Log("Collision enter");
// �浹ü�� Player �϶� Enter�϶��� Exit�϶� 200�� ������ �������� �̵���Ų��
public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("OnCollisionEnter: "+ collision.transform.tag);
            collision.transform.GetComponent<PlayerMove>().PlayerMoveLeft();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("OnCollisionStay: " + collision.transform.tag);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("OnCollisionExit: " + collision.transform.tag);
            collision.transform.GetComponent<PlayerMove>().PlayerMoveLeft();
        }
    }
}
