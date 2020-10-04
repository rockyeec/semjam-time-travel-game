using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowGame : PoiObject
{
    public static bool IsWindowGame { get; private set; }

    public override void OnPress()
    {
        base.OnPress();
        IsWindowGame = true;
        AudioManager.PlayBGM("cricket");
    }
    protected override void OnZoomOut()
    {
        base.OnZoomOut();
        IsWindowGame = false;
        AudioManager.PlayBGM(AudioManager.CurrentMusic);
    }
}
