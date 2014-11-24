using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BuildBehaviour))]
public class BuildSelectable : ObjectSelectable
{
    #region [ FIELDS ]

    private BuildBehaviour buildBehaviour = null;

    #endregion

    #region [ METHODS ]

    protected override void Start()
    {
        base.Start();

        buildBehaviour = GetComponent<BuildBehaviour>();
    }

    #endregion
}