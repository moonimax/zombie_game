using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    public float fTime = 1f;

    private void Start()
    {
        img.color = new Color(0f, 0f, 0f, 1f);
        FadeStart(fTime);
    }

    public void FadeStart(float fadeTime)
    {
        if (fadeTime == 0)
            return;

        StartCoroutine(FadeIn(fadeTime));
    }

    //1초동안 검정색 이미지의 알파값을 조정하여 화면을 밝게 만든다
    //img.color = new Color(0f, 0f, 0f, a); a : 1 -> 0
    IEnumerator FadeIn(float fadeTime)
    {   
        yield return new WaitForSeconds(fadeTime);

        float t = 1f;

        while(t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            
            yield return 0;
        }
    }

    public void FadeTo(string sceneName)
    {
        StartCoroutine (FadeOut(sceneName));
    }

    IEnumerator FadeOut(string sceneName)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);

            yield return 0;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void FadeTo(int sceneNum)
    {
        StartCoroutine(FadeOut(sceneNum));
    }

    IEnumerator FadeOut(int sceneNum)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);

            yield return 0;
        }

        SceneManager.LoadScene(sceneNum);
    }
}
