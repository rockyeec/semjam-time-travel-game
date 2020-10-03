using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadButton : ClickableObject
{
    private Collider2D coll = null;
    public static event System.Action<string> OnKeypadPress = delegate { };
    private static List<KeyPadButton> buttons = new List<KeyPadButton>();
    public static bool CanPress
    {
        set
        {
            foreach (var item in buttons)
            {
                item.coll.enabled = value;
            }
        }
    }
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        buttons.Add(this);
        CanPress = false;
    }
    private void OnDestroy()
    {
        buttons.Clear();
    }

    public override void OnPress()
    {
        AudioManager.PlaySFX("beep");
        OnKeypadPress(name);
    }
}
