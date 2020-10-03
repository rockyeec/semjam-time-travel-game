using System.Collections;
using TMPro;
using UnityEngine;

public class KeyPadScreen : PoiObject
{
    [SerializeField] private TextMeshPro text = null;

    private void Awake()
    {
        KeyPadButton.OnKeypadPress += KeyPadButton_OnKeypadPress;
        ZoomInScript.OnZoomOut += ZoomInScript_OnZoomOut;
    }
    private void OnDestroy()
    {
        KeyPadButton.OnKeypadPress -= KeyPadButton_OnKeypadPress;
        ZoomInScript.OnZoomOut -= ZoomInScript_OnZoomOut;
    }

    public override void OnPress()
    {
        base.OnPress();
        KeyPadButton.CanPress = true;
    }
    private void ZoomInScript_OnZoomOut()
    {
        KeyPadButton.CanPress = false;
    }

    private void KeyPadButton_OnKeypadPress(string obj)
    {
        if (text.text.Length <= 4)
        {
            if (obj.Contains("0"))
            {
                if (text.text.Length != 0)
                {
                    string str = text.text;
                    str = str.Remove(str.Length - 1);
                    text.text = str;
                }
                return;
            }
            if (text.text.Length < 4)
            {
                for (int i = 1; i < 10; i++)
                {
                    string str = i.ToString();
                    if (obj.Contains(str))
                    {
                        text.text += str;
                        return;
                    }
                }
            }
        }
        if (obj.Contains("#"))
        {
            if (text.text == "4175")
            {
                AudioManager.PlaySFX("door open");
                text.text = "Correct!";
                StartCoroutine(PlayEndingScene());
            }
            else
            {
                text.text = string.Empty;
            }
        }
    }

    IEnumerator PlayEndingScene()
    {
        yield return new WaitForSeconds(1.337f);
        FindObjectOfType<GameScript>().WinGame();
    }
}
