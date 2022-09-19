using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    private MapType m_mapType;

    private void Start()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        Color a = render.color;
        if (m_mapType == MapType.������)
            a = new Color(0, 255, 255);
        else if (m_mapType == MapType.����)
            a = new Color(255, 0, 255);
        else
            a = new Color(255, 255, 0);

        render.color = a;
    }

    public void SetMapType(MapType _type)
    {
        m_mapType = _type;
    }
}
