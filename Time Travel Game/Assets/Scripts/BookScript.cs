using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : ClickableObject
{
    Camera cam;

    Vector3 MousePosition
    {
        get
        {
            if (cam == null)
                cam = Camera.main;
            return cam.ScreenToWorldPoint(Input.mousePosition).WithZ(0.0f);
        }
    }

    private void Update()
    {
        if (cam == null)
            cam = Camera.main;
        transform.position = MousePosition;
    }

    private void Awake()
    {
        ZoomInScript.OnZoomOut += ZoomInScript_OnZoomOut;
        enabled = false;
    }
    private void OnDestroy()
    {
        ZoomInScript.OnZoomOut -= ZoomInScript_OnZoomOut;
    }

    private void ZoomInScript_OnZoomOut()
    {
        enabled = false;
    }

    public override void OnPress()
    {
        base.OnPress();
        if (!ShelfScript.IsShelfGame)
            return;

        enabled = true;
    }
    public override void OnRelease()
    {
        base.OnRelease();
        enabled = false;
    }
}
