using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : InventoryItem
{
    [SerializeField] private int number = 1;
    public override void UiUse()
    {
        base.UiUse();
        if (JigsawManager.IsJigsawGame)
        {
            SlotSetup.ShowPieces(number);
            Destroy(UiObject.gameObject);
        }
    }
}
