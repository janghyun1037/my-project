using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour //페이드 아웃, 인 코드
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(false);
        Color alpha = Panel.color;
        while (alpha.a <1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }
}
//이걸 어케 합쳐야 하지? 그냥 페이드 뺼까?