using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Texture2D map;
    public float size = 5;
    public ColorToPrefab[] mappings;

    void Clear()
    {
        for( int i=transform.childCount-1; i>=0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    public void Generate()
    {
        Clear();
        for( int x=0; x<map.width; x++)
        {
            for( int y=0; y<map.height; y++)
            {
                Color color = map.GetPixel(x, y);
                Vector3 position = new Vector3(x,0,y) * size;
                position = transform.TransformPoint(position);
                foreach( var m in mappings )
                {
                    if(m.color == color)
                    {
                        Instantiate(m.prefab, position, Quaternion.identity, transform);
                    }
                }
            }
        }
    }

    [Serializable]
    public class ColorToPrefab
    {
        public Color color;
        public GameObject prefab;
    }
}
