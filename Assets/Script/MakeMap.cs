using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapType
{
    ������, ����, �̺�Ʈ
}
public class MakeMap : MonoBehaviour
{
    const int MAP_LENGTH_SIZE = 5;
    const int MAP_WIDTH_SIZE = 5;
    private MapType[,] m_mapNum = null;
    private int m_mapTypeCount;

    // Start is called before the first frame update
    void Start()
    {
        m_mapTypeCount = System.Enum.GetValues(typeof(MapType)).Length;
        MakeBaseLand();
    }

    private void MakeBaseLand()
    {
        m_mapNum = new MapType[MAP_WIDTH_SIZE, MAP_LENGTH_SIZE];
        for (int length = 0; length < MAP_LENGTH_SIZE; length++)
        {
            for(int width = 0; width < MAP_WIDTH_SIZE; width++)
            {
                int mapType = Random.Range(0, m_mapTypeCount);
                m_mapNum[length, width] = (MapType)mapType;
                Debug.Log("���� " + width + " " + length + "��ġ�� ���� ��� ���� �ش� ����� �Ӽ��� "+(MapType)mapType);

            }
        }
    }
    
}
