using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class HUDIconItem : MonoBehaviour
{
    #region [ FIELDS ]

    [HideInInspector]
    public HUDIconType iconType;
    [HideInInspector]
    public GUIText infoText;

    [SerializeField]
    private HUDAnimationType iconAnimationUp;
    [SerializeField]
    private HUDAnimationType iconAnimationDown;

    private Animator animator;
    private int upOrDownParameter = Animator.StringToHash("UpOrDown");

    #endregion

    #region [ METHODS ]

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartUpAnimation()
    {
        animator.enabled = true;

        animator.SetInteger(upOrDownParameter, (int)iconAnimationUp);
    }

    public void StartDownAnimation()
    {
        animator.SetInteger(upOrDownParameter, (int)iconAnimationDown);
    }

    public void DesactiveAnimationComponent()
    {
        animator.enabled = false;
    }

    void OnMouseDown()
    {
        print("Selecionado: " + iconType);

        switch (iconType)
        {
            case HUDIconType.Info:
                HUDInfo.Instance.OpenInfoModal(infoText);
                break;
            case HUDIconType.CoconutJuice:
                break;
            case HUDIconType.Cocada:
                break;
            case HUDIconType.GuavaJuice:
                break;
            case HUDIconType.Jelly:
                break;
            case HUDIconType.CaneJuice:
                break;
            case HUDIconType.Sugar:
                break;
        }
    }

    #endregion
}