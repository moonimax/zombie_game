using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    public GameObject fakeObject;
    public GameObject breakObject;
    public GameObject sphereObject;

    //숨겨진 아이템
    public GameObject theItem;

    public float health = 1f;
    private bool isBreak = false;

    //아이템을 가지고 있는지
    public bool haveItem = false;

    //깨지지 않는 오브젝트 체크 true:깨지지 않는다
    public bool isUnBreakable = false;

    public void TakeDamage(float damage)
    {
        if(isUnBreakable)
        {
            return;
        }

        health -= damage;

        if (health <= 0f && !isBreak)
        {
            StartCoroutine(Break());
        }
    }

    IEnumerator Break()
    {
        isBreak = true;
        this.GetComponent<BoxCollider>().enabled = false;

        fakeObject.SetActive(false);
        sphereObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        breakObject.SetActive(true);
        AudioManager.instance.Play("PotterySmash");
        yield return new WaitForSeconds(0.1f);

        sphereObject.SetActive(false);

        //숨겨진 아이템 보여주기, 아이템 생성하기
        if (haveItem)
        {
            theItem.SetActive(true);
        }
    }

}
