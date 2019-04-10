using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Projectile", menuName = "Projectile")]
public class BulletData : ScriptableObject
{
   
    public int Damage;
    public float Speed;
    public GameObject projectileview;

}
