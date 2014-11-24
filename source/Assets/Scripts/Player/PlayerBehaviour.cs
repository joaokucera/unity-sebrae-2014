using UnityEngine;
using System.Collections;

public class PlayerBehaviour : CharacterBehaviour
{
    #region [ FIELDS ]

    [SerializeField]

    private PlayerTarget playerTargetScript;

    #endregion

    #region [ METHODS ]

    protected override void UpdateControl()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            playerTargetScript.UpdateTargetPosition();

            CharacterState = CharacterBehaviourState.Walk;

            HUDIconManager.Instance.ActiveIconItems(-1);
        }
    }

    #endregion
}
