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
    const int MAP_HEIGHT_SIZE = 5;
    const int MAP_WIDTH_SIZE = 5;
    public const int MAP_BLOCK_SIZE = 12;
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
                mapBlock.InitialSet((BlockType)mapType);
                m_mapBlocks[length, width] = mapBlock;
             
            }
        }
    }

    private void ReplaceBlock()
    {
        for (int length = 0; length < MAP_HEIGHT_SIZE; length++)
        {
            for (int width = 0; width < MAP_WIDTH_SIZE; width++)
            {
                Vector2 place = new Vector2(width * MAP_BLOCK_SIZE, -length * MAP_BLOCK_SIZE);
                m_mapBlocks[length, width].transform.position = place;
                
            }
        }
    }

    private void OrderExit()
    {
        int xRan = Random.Range(0, MAP_WIDTH_SIZE);
        int yRan = Random.Range(0, MAP_HEIGHT_SIZE);

        m_mapBlocks[yRan, xRan].MakeExit(m_exitGO);
    }
    #endregion

}
