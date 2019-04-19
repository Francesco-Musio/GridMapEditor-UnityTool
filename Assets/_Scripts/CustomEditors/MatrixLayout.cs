using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    [System.Serializable]
    public class MatrixLayout
    {
        [System.Serializable]
        public class rowData
        {
            public bool[] row;
        }

        public int mapWidth = 8;
        public int mapHeight = 8;

        public rowData[] rows;
    }
}
