using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    private void Awake()
    {
        instance = this;
        InventoryItem.OnPickedUp += InventoryItem_OnPickedUp;
    }
    private void OnDestroy()
    {
        InventoryItem.OnPickedUp -= InventoryItem_OnPickedUp;
    }

    private void InventoryItem_OnPickedUp(InventoryItem obj)
    {
        instance.ownedList.Add(obj);

        InventoryUIObject uio = Instantiate(uiObject, inventoryParent.transform).GetComponent<InventoryUIObject>();
        if (uio != null)
        {
            uio.Image.sprite = obj.Sprite;
            uio.Item = obj;
            obj.UiObject = uio;

            obj.transform.SetParent(inventoryParent.transform);
            StartCoroutine(GoToSlot(obj.transform, uio));
        }
    }

    [SerializeField] private InventoryParent inventoryParent = null;
    [SerializeField] private GameObject uiObject = null;
    [SerializeField] private AnimationCurve curve = null;
    private readonly List<InventoryItem> ownedList = new List<InventoryItem>();
    

    IEnumerator GoToSlot(Transform obj, InventoryUIObject uiTrans)
    {
        uiTrans.CanvasGroup.alpha = 0.0f;
        yield return null;
        float elapsed = 0.0f;
        float duration = 0.45f;
        Vector3 startPos = obj.position;
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(uiTrans.transform.position);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = curve.Evaluate(elapsed / duration);
            obj.position = Vector3.Lerp(startPos, targetPos, t);
            uiTrans.CanvasGroup.alpha = Mathf.Lerp(0.0f, 1.0f, t);
            yield return null;
        }
        uiTrans.CanvasGroup.alpha = 1.0f;
        obj.transform.localPosition = Vector3.zero;
    }
}
