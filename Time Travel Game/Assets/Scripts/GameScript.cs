using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer endingScene = null;
    [SerializeField] GameObject environment = null;
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
        AudioManager.PlayBGM("music1");

        MenuManager menu = FindObjectOfType<MenuManager>();       
        menu.PressPlay();
    }

    public void WinGame()
    {
        ZoomInScript.ZoomOut();
        endingScene.gameObject.SetActive(true);
        endingScene.sortingOrder = 100;
        environment.SetActive(false);
    }
}
