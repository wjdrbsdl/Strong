using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    [SerializeField] private GameObject m_mapTile;
    [SerializeField] private Sprite[] m_tileSprites;
    private BlockType m_blockType;
    private GameObject[,] m_tiles;
    private int m_blockSize = MakeMapBlock.MAP_BLOCK_SIZE;

    #region PublicMethod
    public void InitialSet(BlockType _type)
    {
        m_blockSize = MakeMapBlock.MAP_BLOCK_SIZE;
        SetMapType(_type);
        DivideLandAndMakeTile();
    }

    public void MakeExit(GameObject _exitGO)
    {
        int xRan = Random.Range(0, m_blockSize);
        int yRan = Random.Range(0, m_blockSize);
        GameObject exit = Instantiate(_exitGO);
        exit.transform.parent = transform;
        exit.transform.localPosition = m_tiles[yRan, xRan].transform.localPosition;
    }
    #endregion

    #region PrivateMethod
    private void SetMapType(BlockType _type)
    {
        m_blockType = _type;
    }

    private void DivideLandAndMakeTile()
    {
        m_tiles = new GameObject[m_blockSize, m_blockSize];
        Vector2 offset = new Vector2((-m_blockSize / 2), m_blockSize / 2);
        offset.x += m_mapTile.transform.localScale.x / 2;
        offset.y -= m_mapTile.transform.localScale.y / 2;

        for(int height = 0; height < m_blockSize; height++)
        {
            for (int width = 0; width < m_blockSize; width++)
            {
                GameObject tile = Instantiate(m_mapTile);
                tile.transform.parent = transform;
                Vector2 pos = new Vector2(offset.x + width, offset.y - height);
                tile.transform.localPosition = pos;
                m_tiles[height, width] = tile;
                SpriteRenderer tileSprite = tile.GetComponent<SpriteRenderer>();
                TestPatinTile(tileSprite);
            }
        }
    }

    private void TestPatinTile(SpriteRenderer _render)
    {
        if (m_blockType == BlockType.약초터)
        {
            int spriteNum = Random.Range(0, 3);
            _render.sprite = m_tileSprites[spriteNum];
        }
        else if (m_blockType == BlockType.함정)
        {
            int spriteNum = Random.Range(3, 6);
            _render.sprite = m_tileSprites[spriteNum];
        }
        else if (m_blockType == BlockType.이벤트)
        {
            int spriteNum = Random.Range(6, 9);
            _render.sprite = m_tileSprites[spriteNum];
        }

    }
    #endregion
}
