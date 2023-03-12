using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimation : MonoBehaviour
{
    public GameObject torchLight;

    public int lightMode = 0;

    // Update is called once per frame
    void Update()
    {
        if(lightMode == 0)
        {
            StartCoroutine(FlameAnimation());
        }
    }

    IEnumerator FlameAnimation()
    {
        lightMode = Random.Range(1, 4); // 1, 2, 3
        torchLight.GetComponent<Animator>().SetInteger("ModeLight", lightMode);

        yield return new WaitForSeconds(1f);
        lightMode = 0;
    }
}
