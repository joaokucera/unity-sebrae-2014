using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public abstract class ObjectSelectable : MonoBehaviour
{
    #region [ FIELDS ]

    protected const float ResizeBump = 1.2f;
    private GUIText infoText;

    [SerializeField]
    private HUDIconGroup iconGroup;
    [SerializeField]
    private HUDIconType[] iconTypes;
    [SerializeField]
    protected List<GameObject> iconItemPrefabs;

    #endregion

    #region [ METHODS ]

    protected virtual void Start()
    {
        infoText = GetComponentInChildren<GUIText>();

        List<HUDIconItem> iconItemList = new List<HUDIconItem>();

        for (int i = 0; i < iconTypes.Length; i++)
        {
            GameObject newItem = Instantiate(iconItemPrefabs[i]) as GameObject;

            HUDIconItem newIconItem = newItem.GetComponent<HUDIconItem>();
            newIconItem.iconType = iconTypes[i];

            if (newIconItem.iconType == HUDIconType.Info)
            {
                newIconItem.infoText = infoText;
            }

            iconItemList.Add(newIconItem);
        }

        HUDIconManager.Instance.iconItemsDictionary[(int)iconGroup] = iconItemList;
    }

    protected virtual void OnMouseDown()
    {
        StartCoroutine(transform.Bump(ResizeBump));

        HUDIconManager.Instance.ActiveIconItems((int)iconGroup);
    }

    #endregion
}
