using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    #region variables

    public int damage = 2;
    

    #endregion
  
    #region API
    public BulletData PJData;


    //public void Range()
    //{
    //    PJData.range += Time.deltaTime;

    //    if (PJData.range > PJData.maxRange)
    //    {
    //        PJData.range = PJData.maxRange;
    //    }

    //}

   

    /// <summary>
    ///controllo collisioni 
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        

        //se il proiettile colpisce un tank
        if (other.gameObject.GetComponent<TankData>())
        {
            
            //fai danno
            other.gameObject.GetComponent<TankData>().Life = (other.gameObject.GetComponent<TankData>().Life - damage); 

            //se la vita va a zero distruggi il tank
            if(other.gameObject.GetComponent<TankData>().Life <= 0 && other.gameObject.GetComponent(typeof(IDamagable)))
            {
                other.gameObject.SetActive(false);
            }
        }

        //se colpisce un idamageble succederà qualcosa
        if (other.gameObject.GetComponent(typeof(IDamagable)))
        {

        }
    }
    #endregion

}
