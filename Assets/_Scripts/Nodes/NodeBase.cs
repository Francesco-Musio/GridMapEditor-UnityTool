using UnityEngine;
using System.Collections;

public abstract class NodeBase : MonoBehaviour, INode
{
    [Header("Position")]
    [SerializeField]
    private int xCoordinate;
    [SerializeField]
    private int yCoordinate;

    #region API
    public virtual void Init(int _x, int _y)
    {
        xCoordinate = _x;
        yCoordinate = _y;
    }
    #endregion
}
