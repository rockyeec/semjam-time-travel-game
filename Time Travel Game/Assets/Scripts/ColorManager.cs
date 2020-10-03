using System.Collections;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private static ColorManager instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] private AnimationCurve curve = null;
    [SerializeField] private float duration = 1.337f;
    [SerializeField] private Material standardMaterial = null;
    [SerializeField] private Material greyScaleMaterial = null;

    private SpriteRenderer[] renList;
    private void Start()
    {
        StartCoroutine(NextFrameStart());
    }
    IEnumerator NextFrameStart()
    {
        yield return null;
        renList = FindObjectsOfType<SpriteRenderer>();
    }

    public static void ToGreyScale()
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine( instance.Lerp(instance.greyScaleMaterial));
    }
    public static void ToStandard()
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine( instance.Lerp(instance.standardMaterial));
    }

    private IEnumerator Lerp(Material target)
    {
        float elapsed = 0.0f;
        Material start = renList[0].material;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = curve.Evaluate(elapsed / duration);
            foreach (var item in renList)
            {
                item.material.Lerp(start, target, t);
            }
            yield return null;
        }
        foreach (var item in renList)
        {
            item.material = target;
        }
    }
}
