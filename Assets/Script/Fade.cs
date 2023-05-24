using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    [Header("맵 넘어갈 이미지")] public Image Panel;
    float time = 0f;
    float FadeTime = 1f;

    public void FadeMotion()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);

        time = 0f;
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            // 이미지의 알파 값이 1이하일 동안, 화면이 완전히 어두워질 동안
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(1f); // 1초의 대기시간.

        while(alpha.a > 0f)
        {
            // 이미지의 알파 값이 0이상일 동안, 화면이 완전히 밝아질 동안
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
}
