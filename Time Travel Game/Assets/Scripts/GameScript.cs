using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer endingScene = null;
    [SerializeField] GameObject environment = null;
    [SerializeField] CanvasGroup guide = null;

    private void Start()
    {
        endingScene.gameObject.SetActive(false);
        StartCoroutine(StartNextFrame());

        MenuManager menu = FindObjectOfType<MenuManager>();
        menu.gameObject.SetActive(true);
        menu.PressPlay();
    }
    IEnumerator StartNextFrame()
    {
        yield return null;
        AudioManager.CurrentMusic = "music1";
        AudioManager.PlayBGM(AudioManager.CurrentMusic);

        MenuManager menu = FindObjectOfType<MenuManager>();       
        menu.PressMenu();
    }

    public void WinGame()
    {
        guide.alpha = 0.0f;
        ZoomInScript.ZoomOut();
        endingScene.gameObject.SetActive(true);
        endingScene.sortingOrder = 100;
        environment.SetActive(false);
    }
}
