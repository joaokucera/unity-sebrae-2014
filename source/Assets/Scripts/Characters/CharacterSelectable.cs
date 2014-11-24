using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterBehaviour))]
public class CharacterSelectable : ObjectSelectable
{
    #region [ FIELDS ]

    private CharacterBehaviour characterBehaviour = null;

    #endregion

    #region [ METHODS ]

    protected override void Start()
    {
        base.Start();

        characterBehaviour = GetComponent<CharacterBehaviour>();
    }

    #endregion
}