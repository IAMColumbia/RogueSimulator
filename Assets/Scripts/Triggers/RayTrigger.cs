
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Detects target objects along a configurable 2D ray.
/// Fires an event when a new target enters the ray.
/// </summary>
public class RayTrigger : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent onObjectDetected;

    [Header("Ray Settings")]
    [SerializeField]
    private float rayLength = 5f;

    [SerializeField]
    private Vector2 rayDirection = Vector2.down;

    [SerializeField]
    private LayerMask detectionLayers;

    private Collider2D detectedObject;

    public float RayLength => rayLength;
    public Vector2 RayDirection => rayDirection;
    public Collider2D DetectedObject => detectedObject;

    private void Update()
    {
        Collider2D currentTarget = FindTarget();

        if (currentTarget == detectedObject)
            return;

        detectedObject = currentTarget;

        if (detectedObject != null)
        {
            onObjectDetected?.Invoke();
        }
    }

    private Collider2D FindTarget()
    {
        Vector2 direction = transform.TransformDirection(
            rayDirection.normalized
        );

        RaycastHit2D[] hits = Physics2D.RaycastAll(
            transform.position,
            direction,
            rayLength,
            detectionLayers
        );

        foreach (RaycastHit2D hit in hits)
        {
            Collider2D collider = hit.collider;

            // ignore colliders attached to this object or its children.
            if (collider.transform == transform ||
                collider.transform.IsChildOf(transform))
            {
                continue;
            }

            if (collider.CompareTag("Player") ||
                collider.CompareTag("Enemy"))
            {
                return collider;
            }
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector2 direction = transform.TransformDirection(
            rayDirection.normalized
        );

        Gizmos.DrawRay(
            transform.position,
            direction * rayLength
        );
    }
}
