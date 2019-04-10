using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MatrixLayout
{
    [System.Serializable]
    public struct rowData
    {
        public bool[] row;
    }


    public rowData[] rows = new rowData[7];
}
