using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SelectableManager : MonoBehaviour
{
    #region [ FIELDS ]

    public static SelectableManager Instance;

    private List<Transform> characterTargets;
    private List<CharacterBehaviour> characterBehaviours;
    private int currentCharacterId = -1;

    #endregion

    #region [ PROPERTIES ]

    public bool WasSelectedACharacter { get { return currentCharacterId > -1; } }

    public Transform CurrentTarget { get { return characterTargets[currentCharacterId]; } }

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
        characterTargets = new List<Transform>();
        characterBehaviours = GameObject.FindObjectsOfType<CharacterBehaviour>().ToList();

        for (int i = 0; i < characterBehaviours.Count; i++)
        {
            characterBehaviours[i].Id = i;
            characterTargets.Add(characterBehaviours[i].target);
        }

        characterBehaviours.First().CharacterState = CharacterBehaviourState.Walk;
    }

    public void ChangeSelectedCharacter(CharacterBehaviour characterBehaviour)
    {
        characterBehaviours.ForEach(c =>
        {
            if (c.Id == characterBehaviour.Id)
            {
                c.CharacterState = CharacterBehaviourState.Idle;
                currentCharacterId = c.Id;
            }
        });
    }

    public void MoveCurrentCharacter()
    {
        characterBehaviours[currentCharacterId].CharacterState = CharacterBehaviourState.Walk;
    }

    #endregion
}