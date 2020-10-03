using System.Collections;
using System.Linq;
using UnityEngine;

public class PastPresentObject : MonoBehaviour
{
    [SerializeField] private bool isPresentObject = false;
    SpriteRenderer[] ren = null;
    private void Awake()
    {
        TelephoneScript.OnPast += TelephoneScript_OnPast;
        TelephoneScript.OnPresent += TelephoneScript_OnPresent;
    }
    private void OnDestroy()
    {
        TelephoneScript.OnPast -= TelephoneScript_OnPast;
        TelephoneScript.OnPresent -= TelephoneScript_OnPresent;
    }

    private void TelephoneScript_OnPresent()
    {
        gameObject.SetActive(true);
        if (!gameObject.activeSelf)
            return;
        StopAllCoroutines();
        StartCoroutine(Fade(isPresentObject));
    }

    private void TelephoneScript_OnPast()
    {
        gameObject.SetActive(true);
        if (!gameObject.activeSelf)
            return;
        StopAllCoroutines();
        StartCoroutine(Fade(!isPresentObject));
    }

    IEnumerator Fade(bool isActive)
    {
        if (ren == null)
        {
            ren = GetComponentsInChildren<SpriteRenderer>();
            
        }
        if (ren == null)
        {
            if (!isActive)
                gameObject.SetActive(false);
            yield break;
        }
        if (ren.Length == 0)
        {
            if (!isActive)
                gameObject.SetActive(false);
            yield break;
        }

        float elapsed = 0.0f;
        float duration = 0.69f;
        Color ori = ren.FirstOrDefault().color;
        Color target = isActive ? ori.WithAlpha(1.0f) : ori.WithAlpha(0.0f);

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / duration;

            foreach (var item in ren)
            {
                item.color = Color.Lerp(ori, target, t);
            }

            yield return null;
        }
        foreach (var item in ren)
        {
            item.color = target;
        }
        
        if (!isActive)
            gameObject.SetActive(false);
    }
}
