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
}
