using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapType
{
    약초터, 함정, 이벤트
}
public class MakeMapBlock : MonoBehaviour
{
    const int MAP_LENGTH_SIZE = 5;
    const int MAP_WIDTH_SIZE = 5;
    public const int MAP_BLOCK_SIZE = 12;
    private MapBlock[,] m_mapNum = null;
    private int m_mapTypeCount;
    [SerializeField] private GameObject m_mapBlock;
    [SerializeField] private GameObject m_mapBox;

    // Start is called before the first frame update
    void Start()
    {
        m_mapTypeCount = System.Enum.GetValues(typeof(MapType)).Length;
        MakeBlock();
        ReplaceBlock();
    }

    private void MakeBlock()
    {
        m_mapNum = new MapBlock[MAP_WIDTH_SIZE, MAP_LENGTH_SIZE];
        for (int length = 0; length < MAP_LENGTH_SIZE; length++)
        {
            for(int width = 0; width < MAP_WIDTH_SIZE; width++)
            {
                int mapType = Random.Range(0, m_mapTypeCount);
                MapBlock mapBlock = Instantiate(m_mapBlock).GetComponent<MapBlock>();
                mapBlock.SetMapType((MapType)mapType);
                m_mapNum[length, width] = mapBlock;
            }
        }
    }

    private void ReplaceBlock()
    {
        for (int length = 0; length < MAP_LENGTH_SIZE; length++)
        {
            for (int width = 0; width < MAP_WIDTH_SIZE; width++)
            {
                Vector2 place = new Vector2(width * MAP_BLOCK_SIZE, -length * MAP_BLOCK_SIZE);
                m_mapNum[length, width].transform.position = place;
                
            }
        }
    }
    
}
