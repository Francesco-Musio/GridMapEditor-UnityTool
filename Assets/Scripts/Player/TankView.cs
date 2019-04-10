using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{

    public TankData CurrentData;

    private void Awake()
    {
        Init(CurrentData);
    }

    //inizializzazione dei dati
    public void Init(TankData _data)
    {
        if (CurrentData != null)
        {
            _data = CurrentData; 
        }
    }
    #region API
    public void IstantiateView()
    {
        Instantiate(CurrentData.currentview);
    }

    #endregion
}
