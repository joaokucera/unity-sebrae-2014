using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HUDIconManager : MonoBehaviour
{
    #region [ FIELDS ]

    public static HUDIconManager Instance;

    [HideInInspector]
    public Dictionary<int, List<HUDIconItem>> iconItemsDictionary;

    #endregion

    #region [ METHODS ]

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            Array array = Enum.GetValues(typeof(HUDIconGroup));

            iconItemsDictionary = new Dictionary<int, List<HUDIconItem>>();

            for (int i = 0; i < array.Length; i++)
            {
                iconItemsDictionary.Add(i, new List<HUDIconItem>());
            }
        }
    }

    public void ActiveIconItems(int key)
    {
        foreach (var item in iconItemsDictionary)
        {
            if (item.Key == key)
            {
                foreach (var value in item.Value)
                {
                    value.StartUpAnimation();
                }
            }
            else
            {
                foreach (var value in item.Value)
                {
                    value.StartDownAnimation();
                }
            }
        }
    }

    #endregion
}
