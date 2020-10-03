using System.Collections;

public class TelephoneScript : ClickableObject
{
    public static event System.Action OnPresent = delegate { };
    public static event System.Action OnPast = delegate { };
    private bool isPresent = true;
    public override void OnPress()
    {
        ZoomInScript.ZoomInTo(transform.position.WithZ(-10.0f), 2.0f);

        isPresent = !isPresent;

        if (isPresent)
        {
            ColorManager.ToStandard();
            OnPresent();
        }
        else
        {
            ColorManager.ToGreyScale();
            OnPast();
        }
    }
    public override void OnRelease()
    {
        base.OnRelease();

        ZoomInScript.ZoomOut();
    }

    private void Start()
    {
        StartCoroutine(StartNextFrame());
    }
    IEnumerator StartNextFrame()
    {
        yield return null;
        OnPresent();
    }
}
