using System.Collections;
using UnityEngine;

public class ZoomInScript : MonoBehaviour
{
    private static ZoomInScript instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] private AnimationCurve curve = null;
    private Camera cam;
    private readonly float duration = 0.69f;
    public static event System.Action OnZoomOut = delegate { };
    public static void ZoomOut()
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.ZoomTo(Vector3.zero.WithZ(-10.0f), 5.0f));
        OnZoomOut();
    }
    public static void ZoomInTo(Vector3 targetPos, float targetFov)
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.ZoomTo(targetPos.WithZ(-10.0f), targetFov));
    }

    IEnumerator ZoomTo(Vector3 targetPos, float targetFov)
    {
        if (cam == null)
            cam = Camera.main;

        float elapsed = 0.0f;
        Vector3 startPos = transform.position;
        float startFov = cam.orthographicSize;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = curve.Evaluate(elapsed / duration);

            cam.orthographicSize = Mathf.Lerp(startFov, targetFov, t);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }
        cam.orthographicSize = targetFov;
        transform.position = targetPos;
    }
}
