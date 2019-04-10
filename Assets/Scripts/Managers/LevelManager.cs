using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void shoot();
    public shoot ShootEvent;

    private void OnEnable()
    {
        ShootEvent += HandleOnShoot;
    }

    private void OnDisable()
    {
        ShootEvent -= HandleOnShoot;
    }

    public void HandleOnShoot()
    {
        if (ShootEvent != null)
        {

        }
    }

}
