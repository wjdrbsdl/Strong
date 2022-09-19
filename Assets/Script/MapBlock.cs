using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    private MapType m_mapType;
    [SerializeField] private GameObject m_mapTile;

    private void Start()
    {
        PaintLand();
        DivideLand();
    }

    public void SetMapType(MapType _type)
    {
        m_mapType = _type;
    }

    #region PrivateMethod
    private void PaintLand()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        Color a = render.color;
        if (m_mapType == MapType.약초터)
            a = new Color(0, 255, 255);
        else if (m_mapType == MapType.함정)
            a = new Color(255, 0, 255);
        else
            a = new Color(255, 255, 0);

        render.color = a;
    }

    private void DivideLand()
    {
        int size = MakeMapBlock.MAP_BLOCK_SIZE;
        Vector2 offset = new Vector2((-size / 2), size / 2);
        offset.x += 0.5f;
        offset.y -= 0.5f;

        for(int length = 0; length < size; length++)
        {
            for (int width = 0; width < size; width++)
            {
                GameObject tile = Instantiate(m_mapTile);
                tile.transform.parent = transform;
                Vector2 pos = new Vector2(offset.x + width, offset.y - length);
                tile.transform.localPosition = pos;
                tile.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            }
        }
    }
    #endregion
}
