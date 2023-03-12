using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    public GameObject fakeObject;
    public GameObject breakObject;
    public GameObject sphereObject;

    //������ ������
    public GameObject theItem;

    public float health = 1f;
    private bool isBreak = false;

    //�������� ������ �ִ���
    public bool haveItem = false;

    //������ �ʴ� ������Ʈ üũ true:������ �ʴ´�
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

        //������ ������ �����ֱ�, ������ �����ϱ�
        if (haveItem)
        {
            theItem.SetActive(true);
        }
    }

}
