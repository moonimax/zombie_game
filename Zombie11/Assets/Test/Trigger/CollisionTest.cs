using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Collision enter, stay, exit 이벤트 발생할때
// 충돌체가 Player 일때 Debug.Log 이벤트 발생 출력
// Debug.Log("Collision enter");
// 충돌체가 Player 일때 Enter일때와 Exit일때 200의 힘으로 왼쪽으로 이동시킨다
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
