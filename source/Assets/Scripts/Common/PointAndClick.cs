using UnityEngine;
using System.Collections;

public class PointAndClick : MonoBehaviour
{
    #region Fields

    private const float MoveSpeedBase = 3;

    private float moveSpeed = 3;
    private Transform playerTransform;
    private Vector3 destinationPosition;
    private float destinationDistance;

    #endregion

    #region Methods

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        destinationPosition = playerTransform.position;
    }

    void Update()
    {
        destinationDistance = Vector3.Distance(destinationPosition, playerTransform.position);

        if (destinationDistance < 0.5f)
        {
            moveSpeed = 0;
        }
        else if (destinationDistance > 0.5f)
        {
            moveSpeed = PointAndClick.MoveSpeedBase;
        }

        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {
            Plane playerPlane = new Plane(Vector3.up, playerTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                destinationPosition = ray.GetPoint(hitdist);

                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                playerTransform.rotation = targetRotation;
            }
        }

        if (destinationDistance > 0.5f)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
        }
    }

    #endregion
}