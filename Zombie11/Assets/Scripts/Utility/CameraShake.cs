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


    // 일정시간동안 일정범위안에서 흔들린다
    public IEnumerator Shake(float duration, float magnitude)
    {
        //흔들리기전에 가지고 있는 게임 오브젝트의 위치값을 저장
        Vector3 originPosition = transform.localPosition;

        //일정시간(duration)동안 흔들다
        float countdown = 0f;
        while(countdown < duration)
        {
            //실행문
            float x = originPosition.x + Random.Range(-1f, 1f) * magnitude;
            float y = originPosition.y + Random.Range(-1f, 1f) * magnitude;
            float z = originPosition.z;
            transform.localPosition = new Vector3(x, y, z);
            countdown += Time.deltaTime;

            yield return null;
        }

        //모두 흔들고 난 후 게임 오브젝트의 위치값을 처음 위치값으로 리셋
        transform.localPosition = originPosition;

        
    }
}
