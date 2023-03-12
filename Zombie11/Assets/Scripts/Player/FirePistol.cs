using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject theGun;
    //총구 발사 화염
    public GameObject fireFlash;
    
    //연사 방지
    private bool isFire = false;
    //공격력
    //public float attackDamage = 5f;


    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.instance.weaponType == WeaponType.NONE)
            return;

        //Fire1 : 좌측 컨트롤키 또는 마우스 왼쪽 클리시 이벤트 발생
        if(Input.GetButtonDown("Fire1"))
        {
            if (!isFire)
            {
                if (PlayerStats.instance.UseAmmor(1))
                {
                    StartCoroutine(Fire());
                } else
                {
                    Debug.Log("You need to reload");
                }
            }
        }
    }

    IEnumerator Fire()
    {
        isFire = true;
        float attackDamage = PlayerStats.instance.attack.GetValue();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            //충돌체가 있으면 실행
            //hit.transform
            if (hit.transform.tag == "Enemy")
            {
                //데미지 메서드 호출해서 연산
                hit.transform.GetComponent<Zombie>().TakeDamage(attackDamage);
            }
            else if (hit.transform.tag == "BreakObject")
            {
                hit.transform.GetComponent<BreakObject>().TakeDamage(attackDamage);
            }
            else if (hit.transform.tag == "Mutant")
            {
                hit.transform.GetComponent<Mutant>().TakeDamage(attackDamage);
            }

            theGun.GetComponent<Animation>().Play("PistolFireAnim");
            fireFlash.SetActive(true);
            fireFlash.GetComponent<Animation>().Play("FireFlashAnim");
            //총소리
            AudioManager.instance.Play("PistolShot");

            yield return new WaitForSeconds(0.3f);
            fireFlash.SetActive(false);

            isFire = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        float maxDistance = 100f;
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance);
        Gizmos.color = Color.red;
        if (isHit)
        {
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
}
