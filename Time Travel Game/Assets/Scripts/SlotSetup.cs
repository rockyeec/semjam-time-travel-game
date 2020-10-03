using System.Collections.Generic;
using UnityEngine;

public class SlotSetup : MonoBehaviour
{
    [SerializeField] private int rows = 4;
    [SerializeField] private int cols = 4;
    [SerializeField] private Sprite[] spriteList = null;
    [SerializeField] private GameObject jigsawSlotPrefab = null;
    [SerializeField] private GameObject tempJigsawPiecePrefab = null;
    [SerializeField] private Transform tempPiecesStorage = null;
    private void Start()
    {
        PuzzleParent pP = jigsawSlotPrefab.GetComponent<PuzzleParent>();

        float startX = transform.position.x - pP.Width * (cols - 1) / 2.0f;
        float startY = transform.position.y - pP.Height * (rows - 1) / 2.0f;

        float gapX = pP.Width;
        float gapY = pP.Height;

        List<Sprite> tempSpriteList = new List<Sprite>();
        foreach (var item in spriteList)
        {
            tempSpriteList.Add(item);
        }
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                GameObject tempSlot = Instantiate(jigsawSlotPrefab, transform);
                tempSlot.transform.position = new Vector3(startX + x * gapX, startY + (rows - 1 - y) * gapY);
                PuzzleSlot pS = tempSlot.GetComponent<PuzzleSlot>();
                pS.name = spriteList[y * cols + x].name;

                GameObject tempPiece = Instantiate(tempJigsawPiecePrefab, tempPiecesStorage);
                tempPiece.transform.position = new Vector3(startX + x * gapX, startY + (rows - 1 - y) * gapY);
                PuzzlePiece pPc = tempPiece.GetComponent<PuzzlePiece>();
                pPc.Sprite = tempSpriteList.GetRandomAndRemove();

                pS.Put(pPc);
            }
        }
    }
}
