using UnityEngine;
using System.Collections;
using GridMapEditor;

public class LevelManager : MonoBehaviour
{
    private MapManager mapMng;

    private void Start()
    {
        mapMng = GetComponent<MapManager>();
        if (mapMng != null)
            mapMng.Init();
    }
}
