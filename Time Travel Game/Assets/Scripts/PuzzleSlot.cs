
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : PuzzleParent
{
    public override string Name { get { return name; } }
    private PuzzlePiece piece = null;

    private static readonly List<PuzzleSlot> slotList = new List<PuzzleSlot>();
    private void Awake()
    {
        slotList.Add(this);
        DisableColliders();
    }
    private void OnDestroy()
    {
        slotList.Clear();
    }
    public static void DisableColliders()
    {
        foreach (var item in slotList)
        {
            item.Coll.enabled = false;
        }
    }
    public static void EnableColliders()
    {
        foreach (var item in slotList)
        {
            item.Coll.enabled = true;
        }
    }


    public void Put(PuzzlePiece newPiece)
    {
        bool isSwap = false;
        if (piece != null)
        {
            if (piece != newPiece)
            {
                if (newPiece.curSlot != null)
                {
                    newPiece.curSlot.Place(piece, true);
                    isSwap = true;
                }
            }
        }

        Place(newPiece, !isSwap);
    }

    private void Place(PuzzlePiece newPiece, bool isEmptyOldSlot = false)
    {
        if (newPiece != null)
        {
            if (newPiece.curSlot != null && isEmptyOldSlot)
                newPiece.curSlot.piece = null;
            newPiece.curSlot = this;
            newPiece.transform.SetParent(transform);
            newPiece.transform.localPosition = Vector3.zero;
        }
        piece = newPiece;
    }
    private bool IsMatch()
    {
        if (piece == null)
            return false;
        return (Name == piece.Name);
    }
    public static bool IsAllMatch()
    {
        foreach (var item in slotList)
        {
            if (!item.IsMatch())
                return false;
        }
        return true;
    }
}
