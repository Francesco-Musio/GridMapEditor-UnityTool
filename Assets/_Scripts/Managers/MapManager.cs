using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField]
        private MapData mapData;
        [SerializeField]
        private GameObject nodePrefab;

        [Header("Map Options")]
        [SerializeField]
        private Transform mapContainer;

        #region API
        public void Init()
        {
            MatrixLayout.rowData[] rows = mapData.map.rows;

            for (int i = 0; i < rows.Length; i++)
            {
                bool[] _currentRow = rows[i].row;

                for (int j = 0; j < _currentRow.Length; j++)
                {
                    GameObject _newNode = Instantiate(nodePrefab, mapContainer);
                    _newNode.transform.position = new Vector3(i, 0, j);

                    INode node = _newNode.GetComponent<INode>();
                    node.Init(i, j);

                    if (_currentRow[j])
                    {
                        _newNode.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
            }
        }
        #endregion
    }
}
