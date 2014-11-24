using UnityEngine;
using System.Collections;

public class HUDInfo : MonoBehaviour
{
    #region [ FIELDS ]

    public static HUDInfo Instance;

    [HideInInspector]
    public GUIText currentTextInfo;

    [SerializeField]
    private GUITexture modalTexture;

    #endregion

    #region [ METHODS ]

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentTextInfo = null;
    }

    public void OpenInfoModal(GUIText newTextInfo)
    {
        guiTexture.enabled = true;
        modalTexture.enabled = true;

        currentTextInfo = newTextInfo;
        currentTextInfo.enabled = true;
    }

    void OnMouseDown()
    {
        CloseInfoModal();
    }

    private void CloseInfoModal()
    {
        guiTexture.enabled = false;
        modalTexture.enabled = false;

        currentTextInfo.enabled = false;
        currentTextInfo = null;
    }

    #endregion
}
