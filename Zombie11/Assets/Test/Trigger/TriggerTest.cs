using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ʈ���� enter, stay, exit �̺�Ʈ �߻��Ҷ�
// Debug.Log �̺�Ʈ �߻� ���
// Debug.Log("Ʈ���� enter");
// �浹 Enter �ϸ� : �÷��̾� Color Red
// �浹 exit �ϸ� : �÷��̾� ���� Color
// �浹ü�� Player �϶� Enter�� Exit�϶� 200�� ������ ���������� �̵���Ų��
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
