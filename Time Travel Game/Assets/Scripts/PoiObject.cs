using UnityEngine;

public class PoiObject : ClickableObject
{
    [SerializeField] private float zoomSize = 2.0f;
    Collider2D coll;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }
    public override void OnPress()
    {
        ZoomInScript.ZoomInTo(transform.position.WithZ(-10.0f), zoomSize);
        coll.enabled = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            coll.enabled = true;
        }
    }
}
