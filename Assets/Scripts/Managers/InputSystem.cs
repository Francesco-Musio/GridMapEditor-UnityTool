using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    TankView tankView;
    ProjectileController PJcont;
   
    // Use this for initialization
    void Start()
    {
        if (tankView == null)
        {
            tankView = GetComponent<TankView>(); 
        }

        if(PJcont == null)
        {
            PJcont = GetComponent<ProjectileController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Debug.Log(Input.GetAxis("movement"));
    }

    public void Movement(Movement _type)
    {
        switch (_type)
        {
            case global::Movement.Up:
                transform.Translate(Vector3.forward);
                break;
            case global::Movement.Down:
                transform.Translate(Vector3.back);
                break;
        }
       
    }

    public void Rotation(Rotation _type)
    {
        switch (_type)
        {
            case global::Rotation.Left:
                transform.Rotate(Vector3.down);
                break;
            case global::Rotation.Right:
                transform.Rotate(Vector3.up);
                break;
           
        }

    }

    public void CheckInput()
    {
        if (Input.GetAxis("movement") > 0)
        {
            Movement(global::Movement.Up);
        }
        if (Input.GetAxis("movement") < 0)
        {
            Movement(global::Movement.Down);
        }

        if (Input.GetAxis("rotation") > 0)
        {
            Rotation(global::Rotation.Right);
        }
        else if (Input.GetAxis("rotation") < 0)
        {
            Rotation(global::Rotation.Left);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //PJcont.Range();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            
        }
    }
}
public enum Movement
{
    Up,
    Down,
    
}

public enum Rotation
{
    Left, 
    Right,
}
