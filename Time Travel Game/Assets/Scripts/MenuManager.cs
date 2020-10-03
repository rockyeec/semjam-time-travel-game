using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] CanvasGroup menuPage = null;
    [SerializeField] CanvasGroup audioPage = null;
    [SerializeField] CanvasGroup hudPage = null;

    public void PressMenu()
    {
        Time.timeScale = 0.0f;
        StopAllCoroutines();
        StartCoroutine(Fade(hudPage, false));
        StartCoroutine(Fade(menuPage, true));
        StartCoroutine(Fade(audioPage, false));
    }

    public void PressAudio()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(hudPage, false));
        StartCoroutine(Fade(menuPage, false));
        StartCoroutine(Fade(audioPage, true));
    }

    public void PressPlay()
    {
        Time.timeScale = 1.0f;
        StopAllCoroutines();
        StartCoroutine(Fade(hudPage, true));
        StartCoroutine(Fade(menuPage, false));
        StartCoroutine(Fade(audioPage, false));
    }
    public void PressExit()
    {
        Application.Quit();
    }

    IEnumerator Fade(CanvasGroup obj, bool isActive)
    {
        obj.gameObject.SetActive(true);
        float elapsed = 0.0f;
        float duration = 0.69f;
        float ori = obj.alpha;
        float target = isActive ? 1.0f : 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / duration;

            obj.alpha = Mathf.Lerp(ori, target, t);

            yield return null;
        }

        obj.alpha = target;
        if (!isActive)
            obj.gameObject.SetActive(false);
    }
}
