using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {            
            StartCoroutine(Shake(0.15f, 0.25f));
        }
    }


    // �����ð����� ���������ȿ��� ��鸰��
    public IEnumerator Shake(float duration, float magnitude)
    {
        //��鸮������ ������ �ִ� ���� ������Ʈ�� ��ġ���� ����
        Vector3 originPosition = transform.localPosition;

        //�����ð�(duration)���� ����
        float countdown = 0f;
        while(countdown < duration)
        {
            //���๮
            float x = originPosition.x + Random.Range(-1f, 1f) * magnitude;
            float y = originPosition.y + Random.Range(-1f, 1f) * magnitude;
            float z = originPosition.z;
            transform.localPosition = new Vector3(x, y, z);
            countdown += Time.deltaTime;

            yield return null;
        }

        //��� ���� �� �� ���� ������Ʈ�� ��ġ���� ó�� ��ġ������ ����
        transform.localPosition = originPosition;

        
    }
}
