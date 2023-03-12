using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject damageFlash;

    public SceneFader fader;
    public string loadToScene = "GameOver"; //������ �� �̸�

    public Transform firstPersonCharacter;

    public void TakeDamage(float damage)
    {
        if (PlayerStats.instance.isDeath)
            return;

        //���� ���
        damage -= PlayerStats.instance.defense.GetValue();
        if(damage < 0)
        {   
            return;
        }

        PlayerStats.instance.health -= damage;
        Debug.Log("Player health : " + PlayerStats.instance.health);

        StartCoroutine(firstPersonCharacter.GetComponent<CameraShake>().Shake(0.25f, 0.3f));
        StartCoroutine(DamageEffect());

        if (PlayerStats.instance.health <= 0f && !PlayerStats.instance.isDeath)
        {
            Die();
        }
    }

    IEnumerator DamageEffect()
    {
        damageFlash.SetActive(true);

        //������ ����(3��) ���� �÷��� : hurt01, hurt02, hurt03
        int rand = Random.Range(1, 4);
        if(rand == 1)
        {
            AudioManager.instance.Play("Hurt01");
        } else if(rand == 2)
        {
            AudioManager.instance.Play("Hurt02");
        } else //if(rand == 3)
        {
            AudioManager.instance.Play("Hurt03");
        }

        yield return new WaitForSeconds(1.0f);
        damageFlash.SetActive(false);
    }

    private void Die()
    {
        PlayerStats.instance.isDeath = true; 
        
        //���ӿ��� ������ �Ѿ��
        fader.FadeTo(loadToScene);
    }
}
