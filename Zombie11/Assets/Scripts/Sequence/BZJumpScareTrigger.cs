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
        //트리거 비활성화
        this.GetComponent<BoxCollider>().enabled = false;

        //문여는 애니메이션
        theDoor.GetComponent<Animation>().Play("Door1OpenAnim");
        //문 열리는 소리
        AudioManager.instance.Play("DoorBang");

        //문 뒤의 좀비 활성화        
        GameObject theZombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        //theZombie.SetActive(true);

        yield return new WaitForSeconds(1f);

        //배경음을 변경
        AudioManager.instance.PlayBgm("JumpscareTune");

        theZombie.GetComponent<Zombie>().Chaser();
    }
}
