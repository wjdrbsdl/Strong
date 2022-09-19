using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    private BlockType m_mapType;
    [SerializeField] private GameObject m_mapTile;
    private GameObject[,] m_tiles;
    private int m_blockSize = MakeMapBlock.MAP_BLOCK_SIZE;

    private void Start()
    {
        PaintLand();
        DivideLandAndMakeTile();
    }

    public void SetMapType(BlockType _type)
    {
        m_mapType = _type;
    }

    public void MakeExit(GameObject _exitGO)
    {
        int xRan = Random.Range(0, m_blockSize);
        int yRan = Random.Range(0, m_blockSize);
        GameObject exit = Instantiate(_exitGO);
        exit.transform.parent = transform;
        exit.transform.localPosition = new Vector2(xRan, yRan);
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
        m_tiles = new GameObject[m_blockSize, m_blockSize];
        Vector2 offset = new Vector2((-m_blockSize / 2), m_blockSize / 2);
        offset.x += 0.5f;
        offset.y -= 0.5f;

        for(int height = 0; height < m_blockSize; height++)
        {
            for (int width = 0; width < m_blockSize; width++)
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
