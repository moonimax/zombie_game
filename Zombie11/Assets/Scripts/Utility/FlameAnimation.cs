using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimation : MonoBehaviour
{
    public GameObject torchLight;

    public float flameTimer = 1f;
    private float countdown = 0f;

    private int lightMode = 0;    

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("PlayAnimation", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(countdown <= 0f)
        {
            //flameTimer초 마다 실행
            PlayAnimation();
            countdown = flameTimer;
        }
        countdown -= Time.deltaTime;
        */

        if (lightMode == 0)
        {
            StartCoroutine(LightAnimation());
        }
    }

    IEnumerator LightAnimation()
    {
        lightMode = Random.Range(1, 4);
        if (lightMode == 1)
        {
            torchLight.GetComponent<Animation>().Play("TorchLightAnim01");
        }
        else if (lightMode == 2)
        {
            torchLight.GetComponent<Animation>().Play("TorchLightAnim02");
        }
        else
        {
            torchLight.GetComponent<Animation>().Play("TorchLightAnim03");
        }

        yield return new WaitForSeconds(1f);
        lightMode = 0;
    }

    private void PlayAnimation()
    {
        lightMode = Random.Range(1, 4);
        if (lightMode == 1)
        {
            torchLight.GetComponent<Animation>().Play("TorchLightAnim01");
        }
        else if (lightMode == 2)
        {
            torchLight.GetComponent<Animation>().Play("TorchLightAnim02");
        }
        else
        {
            torchLight.GetComponent<Animation>().Play("TorchLightAnim03");
        }
    }
}
