using UnityEngine;

public class PoiClickManager : MonoBehaviour
{
    Camera cam;

    ClickableObject curPoi = null;
    private void Update()
    {
        if (Time.timeScale == 0.0f)
            return;

        if (cam == null)
            cam = Camera.main;

        if (Input.GetMouseButtonDown(1))
        {
            ZoomInScript.ZoomOut();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
            if (hit)
            {
                curPoi = hit.collider.GetComponent<ClickableObject>();
                if (curPoi != null)
                {
                    curPoi.OnPress();
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (curPoi != null)
            {
                curPoi.OnRelease();
                curPoi = null;
            }
        }
    }
}
