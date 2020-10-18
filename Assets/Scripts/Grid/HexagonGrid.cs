using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonGrid : MonoBehaviour
{
    public Transform hexPrefab;


    [SerializeField]
    public int width, height = 0;
    [SerializeField]
    public float gap = 0.0f;

    private Vector2 startPos = new Vector2(0, 0);
    private Vector2 spriteSize;
    // Start is called before the first frame update
    void Start()
    {
        spriteSize = hexPrefab.GetComponent<SpriteRenderer>().sprite.rect.size;
        AddGap();
        CalcStartPosition();
        CreateGrid();
    }

    void AddGap()
    {
        spriteSize += spriteSize * gap;
    }

    void CalcStartPosition()
    {
        //startPos = startPos;
    }

    Vector2 CalcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if(gridPos.x % 2 != 0)
        {
            offset = spriteSize.y / 2;
        }

        float worldPosX = startPos.x + 
            gridPos.x * spriteSize.x * 0.75f;
        float worldPosY = startPos.y + 
            gridPos.y * spriteSize.y * 0.90f + offset;

        return new Vector2(worldPosX, worldPosY);
    }

    void CreateGrid()
    {
        for(int x = 0; x < width; ++x)
        {
            for(int y = 0; y < height; ++y)
            {
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);
                hex.position = CalcWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hex(" + x + ", " + y + ")";
            }
        }
    }
}
