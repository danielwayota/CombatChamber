using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float panSpeed;

    /// =============================================
    /// <summary>
    ///
    /// </summary>
    void Update()
    {
        if (this.target == null)
            return;

        Vector3 targetPosition = this.target.position + offset;

        this.transform.position = Vector3.Lerp(
            this.transform.position,
            targetPosition,
            Time.deltaTime * this.panSpeed
        );
    }
}
