using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : PuzzleParent
{
    Camera cam;
    private bool isSelected = false;
    [HideInInspector] public PuzzleSlot curSlot = null;

    public static event System.Action OnPieceSelect = delegate { };
    public static event System.Action OnPieceDeselect = delegate { };


    public override string Name { get { return Ren.sprite.name; } }

    public override void OnPress()
    {
        isSelected = true;
        Ren.sortingOrder += 1;
        OnPieceSelect();
    }
    public override void OnRelease()
    {
        if (cam == null)
            cam = Camera.main;

        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
        if (hit)
        {
            PuzzleSlot newSlot = hit.collider.GetComponent<PuzzleSlot>();
            if (newSlot != null)
                newSlot.Put(this);
        }
        else if (curSlot != null)
        {
            curSlot.Put(this);
        }

        isSelected = false;
        Ren.sortingOrder -= 1;
        OnPieceDeselect();
    }


    private static readonly List<PuzzlePiece> pieceList = new List<PuzzlePiece>();
    private void Awake()
    {
        pieceList.Add(this);
        DisableColliders();
    }
    private void OnDestroy()
    {
        pieceList.Clear();
    }
    public static void DisableColliders()
    {
        foreach (var item in pieceList)
        {
            item.Coll.enabled = false;
        }
    }
    public static void EnableColliders()
    {
        foreach (var item in pieceList)
        {
            item.Coll.enabled = true;
        }
    }
    private void Update()
    {
        if (isSelected)
        {
            if (cam == null)
                cam = Camera.main;

            transform.position = cam.ScreenToWorldPoint(Input.mousePosition).WithZ(0.0f);
        }
    }
}
