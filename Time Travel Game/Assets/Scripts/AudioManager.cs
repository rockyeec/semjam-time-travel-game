using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region singleton
    private static AudioManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] private AudioSource sfxSource = null;
    [SerializeField] private AudioSource bgmSource = null;

    [SerializeField] private AudioClip[] clipList = null;
    private readonly Dictionary<string, AudioClip> clipDic = new Dictionary<string, AudioClip>();

    public static string CurrentMusic { get; set; }

    public static float SfxVolume { set { instance.sfxSource.volume = value; } }
    public static float BgmVolume { set { instance.bgmSource.volume = value; } }

    private void Start()
    {
        foreach (var item in clipList)
        {
            clipDic.Add(item.name, item);
        }
    }

    public static void PlaySFX(string sfxName, in Vector3? point = null)
    {
        instance.sfxSource.transform.position = point ?? Vector3.zero;
        instance.sfxSource.PlayOneShot(instance.clipDic[sfxName]);
    }
    public static void PlayBGM(string bgmName)
    {
        if (instance.bgmSource.clip != null &&
            instance.bgmSource.clip.name == bgmName)
            return;
        instance.bgmSource.clip = instance.clipDic[bgmName];
        instance.bgmSource.Play();
    }
}
