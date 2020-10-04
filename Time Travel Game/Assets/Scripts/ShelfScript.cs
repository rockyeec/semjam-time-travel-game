using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : PoiObject
{
    public static bool IsShelfGame { get; private set; }

    public override void OnPress()
    {
        base.OnPress();
        IsShelfGame = true;
    }
    protected override void OnZoomOut()
    {
        base.OnZoomOut();
        IsShelfGame = false;
    }
}
