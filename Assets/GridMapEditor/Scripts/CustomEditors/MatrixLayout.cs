using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Map
{
    [System.Serializable]
    public class MatrixLayout
    {
        public int mapWidth = 8;
        public int mapHeight = 8;
        //public int startX = 0;
        //public int startY = 0;
        //public int endX = 0;
        //public int endY = 0;

        public rowData[] rows;

        public TileDictionaryElement[] tiles = { new TileDictionaryElement("Default") };

        public Color[] tilesColor = { Color.yellow };
    }
    
    [System.Serializable]
    public class TileDictionaryElement
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public GameObject prefab;

        public TileDictionaryElement(string _name)
        {
            name = _name;
            prefab = null;
        }
    }

    [System.Serializable]
    public class rowData
    {
        public Tile[] row;
    }

    [System.Serializable]
    public class Tile
    {
        public int type = 0;
    }
}


