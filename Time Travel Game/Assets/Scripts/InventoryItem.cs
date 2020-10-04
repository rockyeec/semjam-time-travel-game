using UnityEngine;

public class InventoryItem : ClickableObject
{
    public static event System.Action<InventoryItem> OnPickedUp = delegate { };

    public Sprite Sprite { get; private set; }
    public InventoryUIObject UiObject { get; set; }

    protected virtual void Start()
    {
        SpriteRenderer ren = GetComponentInChildren<SpriteRenderer>();
        if (ren != null)
        {
            Sprite = ren.sprite;
        }
    }

    public override void OnPress()
    {
        base.OnPress();
        OnPickedUp(this);
    }

    public virtual void UiUse() { }
}
