using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinoItem : InventoryItem
{
    [SerializeField] GameObject mask = null;
    Camera cam;
    public override void UiUse()
    {
        base.UiUse();

        if (!WindowGame.IsWindowGame)
        {
            ZoomInScript_OnZoomOut();
            return;
        }
        print("noob hai");

        mask.SetActive(true);
        enabled = true;
    }

    protected override void Start()
    {
        base.Start();
        ZoomInScript.OnZoomOut += ZoomInScript_OnZoomOut;
        ZoomInScript_OnZoomOut();
    }
    private void OnDestroy()
    {
        ZoomInScript.OnZoomOut -= ZoomInScript_OnZoomOut;
    }
    private void ZoomInScript_OnZoomOut()
    {
        mask.SetActive(false);
        enabled = false;
    }
    private void Update()
    {
        if (cam == null)
            cam = Camera.main;
        mask.transform.position = cam.ScreenToWorldPoint(Input.mousePosition).WithZ(0.0f);
    }
}
