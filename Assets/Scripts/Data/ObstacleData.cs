using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "obstacle", menuName = "Obstacle")]
public class ObstacleData : ScriptableObject
{
    public int Life;
    public GameObject ObstacleView;
}
