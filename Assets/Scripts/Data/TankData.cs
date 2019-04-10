using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank", menuName = "Tank")]
public class TankData : ScriptableObject
{
    public int ID;
    public int Life;
    public GameObject currentview;
    public float MovementSpeed;
    public float RotationSpeed;
    public BulletType BulletType;
   


}

public enum BulletType
{
    Missile,
    Other
}
