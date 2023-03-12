using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZJumpScareTrigger : MonoBehaviour
{
    public GameObject theDoor;

    private GameObject zombiePrefab;
    public Transform spawnPoint;

    private void Start()
    {
        zombiePrefab = Resources.Load<GameObject>("Prefabs/Zombie");
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(SequencePlayer());  
    }

    IEnumerator SequencePlayer()
    {
        //Ʈ���� ��Ȱ��ȭ
        this.GetComponent<BoxCollider>().enabled = false;

        //������ �ִϸ��̼�
        theDoor.GetComponent<Animation>().Play("Door1OpenAnim");
        //�� ������ �Ҹ�
        AudioManager.instance.Play("DoorBang");

        //�� ���� ���� Ȱ��ȭ        
        GameObject theZombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        //theZombie.SetActive(true);

        yield return new WaitForSeconds(1f);

        //������� ����
        AudioManager.instance.PlayBgm("JumpscareTune");

        theZombie.GetComponent<Zombie>().Chaser();
    }
}
