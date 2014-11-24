using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTarget : MonoBehaviour
{
    #region [ FIELDS ]

    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Transform target;

    private AIPath[] paths;
    private Camera mainCamera;

    #endregion

    #region [ METHODS ]

    public void Start()
    {
        mainCamera = Camera.main;

        paths = FindObjectsOfType(typeof(AIPath)) as AIPath[];
    }

    public void UpdateTargetPosition()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask) && hit.point != target.position)
        {
            target.position = hit.point;

            if (paths != null)
            {
                for (int i = 0; i < paths.Length; i++)
                {
                    if (paths[i] != null)
                    {
                        paths[i].SearchPath();
                    }
                }
            }
        }
    }

    #endregion
}
