using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileView : MonoBehaviour
{
    public BulletData CurrentPJData;

    private void Awake()
    {
        
    }

    public void Init(BulletData PJdata)
    {
        if(CurrentPJData != null)
        {
            PJdata = CurrentPJData;
        }
    }

    public void InstantiatePJView()
    {
        Instantiate(CurrentPJData.projectileview);
    }
}
