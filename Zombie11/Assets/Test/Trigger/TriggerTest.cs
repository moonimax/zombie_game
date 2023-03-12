using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//트리거 enter, stay, exit 이벤트 발생할때
// Debug.Log 이벤트 발생 출력
// Debug.Log("트리거 enter");
// 충돌 Enter 하면 : 플레이어 Color Red
// 충돌 exit 하면 : 플레이어 원래 Color
// 충돌체가 Player 일때 Enter와 Exit일때 200의 힘으로 오른쪽으로 이동시킨다
public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerEnter");
            other.transform.GetComponent<PlayerMove>().SetPlayerColor(Color.red);
            other.transform.GetComponent<PlayerMove>().PlayerMoveRight();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerExit");
            other.transform.GetComponent<PlayerMove>().ResetPlayerColor();
            other.transform.GetComponent<PlayerMove>().PlayerMoveRight();
        }
    }
}
