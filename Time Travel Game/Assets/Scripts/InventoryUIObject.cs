using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUIObject : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CanvasGroup canvasGroup = null;
    [SerializeField] private Image image = null;
    public CanvasGroup CanvasGroup { get { return canvasGroup; } }
    public Image Image { get { return image; } }
    public InventoryItem Item { get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        Item.UiUse();
    }
}
