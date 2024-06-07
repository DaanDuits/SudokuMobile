using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingFadeInOut : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float intensity;
    [SerializeField] AnimationCurve curve;
    [SerializeField] PostProcessVolume volume;

    public void Fade(bool fadeIn)
    {
        if (fadeIn)
        {
            StartCoroutine(FadeIn());
            return;
        }

        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        float t = 0;

        while (true) 
        { 
            volume.profile.GetSetting<Vignette>().intensity.value = Mathf.LerpUnclamped(0, intensity, curve.Evaluate(t));
            t += Time.deltaTime * speed;
            if (t > 1)
            {
                break;
            }

            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        float t = 0;

        while (true)
        {
            volume.profile.GetSetting<Vignette>().intensity.value = Mathf.LerpUnclamped(intensity, 0, curve.Evaluate(t));
            t += Time.deltaTime * speed;

            if (t > 1)
            {
                break;
            }

            yield return null;
        }
    }
}
