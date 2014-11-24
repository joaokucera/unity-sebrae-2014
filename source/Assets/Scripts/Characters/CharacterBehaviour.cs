using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public abstract class CharacterBehaviour : AIPath
{
    #region [ FIELDS ]

    private CharacterBehaviourState characterState;
    private CharacterAnimation characterAnimation;
    private int id;

    private GameObject endOfPathEffect = null;
    private float sleepVelocity = 0.4F;
    private Vector3 lastTarget;

    #endregion

    #region [ PROPERTIES ]

    public int Id { get { return id; } set { id = value; } }

    public CharacterBehaviourState CharacterState
    {
        get { return characterState; }
        set
        {
            characterState = value;

            switch (characterState)
            {
                case CharacterBehaviourState.Idle:
                    {
                        canMove = false;

                        break;
                    }
                case CharacterBehaviourState.Walk:
                    {
                        canMove = true;

                        break;
                    }
            }
        }
    }

    #endregion

    #region [ METHODS ]

    public new void Start()
    {
        characterAnimation = new CharacterAnimation();
        CharacterState = CharacterBehaviourState.Idle;

        base.Start();
    }

    protected new void Update()
    {
        UpdateControl();

        Vector3 velocity = Vector3.zero;

        if (characterState == CharacterBehaviourState.Walk)
        {
            Vector3 direction = CalculateVelocity(GetFeetPosition());
            RotateTowards(targetDirection);

            direction.y = 0;
            if (direction.sqrMagnitude <= sleepVelocity * sleepVelocity)
            {
                direction = Vector3.zero;
            }

            if (navController != null)
            {
                velocity = Vector3.zero;
            }
            else if (controller != null)
            {
                controller.SimpleMove(direction);
                velocity = controller.velocity;
            }
        }

        characterAnimation.Update(Time.deltaTime, velocity);
    }

    protected abstract void UpdateControl();

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Trigger")
        {
            CharacterState = CharacterBehaviourState.Idle;
        }
    }

    public override void OnTargetReached()
    {
        if (endOfPathEffect != null && Vector3.Distance(tr.position, lastTarget) > 1)
        {
            GameObject.Instantiate(endOfPathEffect, tr.position, tr.rotation);
            lastTarget = tr.position;
        }
    }

    public override Vector3 GetFeetPosition()
    {
        return tr.position;
    }

    #endregion
}
