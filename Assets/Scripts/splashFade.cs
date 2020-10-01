using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class splashFade : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;
    private RawImage splashImage;

    private void Awake()
    {
        splashImage = GetComponent<RawImage>();
        StartCoroutine(Fade(1, 0));
        
    }
    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
            Color color = splashImage.color;
            color.a = Mathf.Lerp(start, end, percent);
            splashImage.color = color;
            yield return null;
        }
    }
}