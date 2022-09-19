using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    private BlockType m_mapType;
    [SerializeField] private GameObject m_mapTile;
    private GameObject[,] m_tiles;

    private void Start()
    {
        PaintLand();
        DivideLandAndMakeTile();
    }

    public void SetMapType(BlockType _type)
    {
        m_mapType = _type;
    }

    #region PrivateMethod
    private void PaintLand()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        Color a = render.color;
        if (m_mapType == BlockType.약초터)
            a = new Color(0, 255, 255);
        else if (m_mapType == BlockType.함정)
            a = new Color(255, 0, 255);
        else
            a = new Color(255, 255, 0);

        render.color = a;
    }

    private void DivideLandAndMakeTile()
    {
        int blockSize = MakeMapBlock.MAP_BLOCK_SIZE;
        m_tiles = new GameObject[blockSize, blockSize];
        Vector2 offset = new Vector2((-blockSize / 2), blockSize / 2);
        offset.x += 0.5f;
        offset.y -= 0.5f;

        for(int height = 0; height < blockSize; height++)
        {
            for (int width = 0; width < blockSize; width++)
            {
                GameObject tile = Instantiate(m_mapTile);
                tile.transform.parent = transform;
                Vector2 pos = new Vector2(offset.x + width, offset.y - height);
                tile.transform.localPosition = pos;
                tile.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                m_tiles[height, width] = tile;
            }
        }
    }
    #endregion
}
