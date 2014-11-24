using UnityEngine;
using System.Collections;

public class InternBehaviour : CharacterBehaviour
{
    #region [ FIELDS ]

    [HideInInspector]
    public FruitTarget fruitTarget;
    [HideInInspector]
    public MachineTarget machineTarget;

    #endregion

    #region [ METHODS ]

    protected override void UpdateControl()
    {

    }

    #endregion
}