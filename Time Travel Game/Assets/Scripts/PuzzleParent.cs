using System.Collections;
using UnityEngine;

public abstract class PuzzleParent : ClickableObject
{
    public float Width { get { return ren.bounds.size.x; } }
    public float Height { get { return ren.bounds.size.y; } }

    public Sprite Sprite { set { ren.sprite = value; } }
    public abstract string Name { get; }

    protected SpriteRenderer Ren { get { return ren; } }
    protected Collider2D Coll { get { return coll; } }

    [SerializeField] private SpriteRenderer ren = null;
    [SerializeField] private Collider2D coll = null;

    public void Hide()
    {
        ren.enabled = false;
    }
    public void Show()
    {
        ren.enabled = true;
        StartCoroutine(LerpShow());
    }

    IEnumerator LerpShow()
    {
        float elapsed = 0.0f;
        float duration = 0.69f;
        Color a = ren.color.WithAlpha(0.0f);
        Color b = ren.color.WithAlpha(1.0f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            ren.color = Color.Lerp(a, b, t);
            yield return null;
        }
        ren.color = b;
    }
}
