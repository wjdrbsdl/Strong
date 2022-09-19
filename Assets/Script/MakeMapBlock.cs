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
    private MapType[,] m_mapNum = null;
    private int m_mapTypeCount;
    [SerializeField] private GameObject m_mapBlock; 

    // Start is called before the first frame update
    void Start()
    {
        m_mapTypeCount = System.Enum.GetValues(typeof(MapType)).Length;
        MakeBlock();
        ReplaceBlock();
    }

    private void MakeBlock()
    {
        m_mapNum = new MapType[MAP_WIDTH_SIZE, MAP_LENGTH_SIZE];
        for (int length = 0; length < MAP_LENGTH_SIZE; length++)
        {
            for(int width = 0; width < MAP_WIDTH_SIZE; width++)
            {
                int mapType = Random.Range(0, m_mapTypeCount);
                m_mapNum[length, width] = (MapType)mapType;
                

            }
        }
    }

    private void ReplaceBlock()
    {
        float xScale = m_mapBlock.transform.localScale.x;
        float yScale = m_mapBlock.transform.localScale.y;
        for (int length = 0; length < MAP_LENGTH_SIZE; length++)
        {
            for (int width = 0; width < MAP_WIDTH_SIZE; width++)
            {
                MapBlock mapBlock = Instantiate(m_mapBlock).GetComponent<MapBlock>();
                Vector2 place = new Vector2(width * xScale, length * yScale);
                mapBlock.transform.position = place;
                mapBlock.SetMapType(m_mapNum[length, width]);
            }
        }
    }
    
}
