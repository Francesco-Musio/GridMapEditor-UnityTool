using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField]
        private MapData mapData;

        [Header("Map Options")]
        [SerializeField]
        private Transform mapContainer;

        #region API
        public void Init()
        {
            rowData[] rows = mapData.map.rows;

            for (int i = 0; i < rows.Length; i++)
            {
                Tile[] _currentRow = rows[i].row;

                for (int j = 0; j < _currentRow.Length; j++)
                { 
                    GameObject _newNode = Instantiate(mapData.map.tiles[_currentRow[j].type].prefab, mapContainer);
                    _newNode.transform.position = new Vector3(i, 0, j);

                    INode node = _newNode.GetComponent<INode>();
                    node.Init(i, j);
                }
            }
        }
        #endregion
    }
}
