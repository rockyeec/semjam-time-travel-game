using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvGame : PoiObject
{
    public static bool IsTvGame { get; private set; }
    [SerializeField] private SpriteRenderer pastRen = null;
    [SerializeField] private SpriteRenderer presentRen = null;
    [SerializeField] private Sprite off = null;
    [SerializeField] private Sprite past = null;
    [SerializeField] private Sprite present = null;
    private static TvGame instance = null;
    private void Awake()
    {
        instance = this;
        instance.pastRen.sprite = instance.off;
        instance.presentRen.sprite = instance.off;
    }

    public override void OnPress()
    {
        base.OnPress();
        IsTvGame = true;
    }
    protected override void OnZoomOut()
    {
        base.OnZoomOut();
        IsTvGame = false;
    }

    public static void TurnOn()
    {
        instance.pastRen.sprite = instance.past;
        instance.presentRen.sprite = instance.present;
        AudioManager.CurrentMusic = "kids tv";
        AudioManager.PlayBGM(AudioManager.CurrentMusic);
    }
    public static void TurnOff()
    {
        instance.pastRen.sprite = instance.off;
        instance.presentRen.sprite = instance.off;
        AudioManager.CurrentMusic = "music1";
        AudioManager.PlayBGM(AudioManager.CurrentMusic);
    }

}
