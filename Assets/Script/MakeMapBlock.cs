using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    약초터, 함정, 이벤트
}

public enum TileType
{
    녹지, 늪지, 물가, 사막
}

public class MakeMapBlock : MonoBehaviour
{
    const int MAP_HEIGHT_SIZE = 7;
    const int MAP_WIDTH_SIZE = 7;
    public const int MAP_BLOCK_SIZE = 60;
    private MapBlock[,] m_mapBlocks = null;
    [SerializeField] private GameObject m_mapBlockGO;
    [SerializeField] private GameObject m_mapBox;
    [SerializeField] private GameObject m_exitGO;

    // Start is called before the first frame update
    void Start()
    {
        MakeBlock();
        ReplaceBlock();
        OrderExit();
    }

    #region PrivateMethod
    private void MakeBlock()
    {
        int mapTypeCount = System.Enum.GetValues(typeof(BlockType)).Length;
        m_mapBlocks = new MapBlock[MAP_WIDTH_SIZE, MAP_HEIGHT_SIZE];
        for (int length = 0; length < MAP_HEIGHT_SIZE; length++)
        {
            for(int width = 0; width < MAP_WIDTH_SIZE; width++)
            {
                int mapType = Random.Range(0, mapTypeCount);
                MapBlock mapBlock = Instantiate(m_mapBlockGO).GetComponent<MapBlock>();
                mapBlock.transform.parent = m_mapBox.transform;
                mapBlock.InitialSet((BlockType)mapType);
                m_mapBlocks[length, width] = mapBlock;
             
            }
        }
    }

    private void ReplaceBlock()
    {
        Vector2 offset = new Vector2(-(MAP_BLOCK_SIZE*MAP_WIDTH_SIZE / 2), MAP_BLOCK_SIZE * MAP_HEIGHT_SIZE / 2);

        offset.x += MAP_BLOCK_SIZE / 2;
        offset.y -= MAP_BLOCK_SIZE / 2;
            
        for (int length = 0; length < MAP_HEIGHT_SIZE; length++)
        {
            for (int width = 0; width < MAP_WIDTH_SIZE; width++)
            {
                Vector2 place = new Vector2(offset.x + width * MAP_BLOCK_SIZE, offset.y - length * MAP_BLOCK_SIZE);
                m_mapBlocks[length, width].transform.localPosition = place;
                
            }
        }
    }

    private void OrderExit()
    {
        int xRan = Random.Range(0, MAP_WIDTH_SIZE);
        int yRan = Random.Range(0, MAP_HEIGHT_SIZE);
        MapBlock randomBlock = m_mapBlocks[yRan, xRan];
        randomBlock.MakeExit(m_exitGO);
    }
    #endregion

}
