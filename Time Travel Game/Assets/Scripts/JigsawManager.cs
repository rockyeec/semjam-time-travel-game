﻿using UnityEngine;

public class JigsawManager : PoiObject
{
    public static bool IsJigsawGame { get; private set; }

    private void Awake()
    {
        PuzzlePiece.OnPieceSelect += PuzzlePiece_OnPieceSelect;
        PuzzlePiece.OnPieceDeselect += PuzzlePiece_OnPieceDeselect;
        ZoomInScript.OnZoomOut += ZoomInScript_OnZoomOut;
    }
    private void OnDestroy()
    {
        PuzzlePiece.OnPieceSelect -= PuzzlePiece_OnPieceSelect;
        PuzzlePiece.OnPieceDeselect -= PuzzlePiece_OnPieceDeselect;
        ZoomInScript.OnZoomOut -= ZoomInScript_OnZoomOut;
    }

    private void ZoomInScript_OnZoomOut()
    {
        PuzzlePiece.DisableColliders();
        IsJigsawGame = false;
    }

    private void PuzzlePiece_OnPieceDeselect()
    {
        PuzzleSlot.DisableColliders();
        PuzzlePiece.EnableColliders();

        if (PuzzleSlot.IsAllMatch())
            print("hallelujah");
    }

    private void PuzzlePiece_OnPieceSelect()
    {
        PuzzleSlot.EnableColliders();
        PuzzlePiece.DisableColliders();
    }

    public override void OnPress()
    {
        base.OnPress();

        PuzzlePiece.EnableColliders();
        IsJigsawGame = true;
    }
}
