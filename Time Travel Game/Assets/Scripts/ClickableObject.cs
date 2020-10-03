using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    public virtual void OnPress() { }

    public virtual void OnRelease() { }
}
