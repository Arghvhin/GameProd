using UnityEngine;

public class openChest : MonoBehaviour
{
    public GameObject targetObject; // The object to be rotated
    public float rotationSpeed = 18f; // Adjust speed as needed
    public float targetRotation = -90f; // Target rotation angle
    private float currentRotation = 0f;
    public bool isRotating = false;

    void Update()
    {

        if (isRotating)
        {
            RotateTowardsTarget();
        }
    }

    void StartRotation()
    {
        isRotating = true;
        currentRotation = targetObject.transform.rotation.eulerAngles.x;
    }

    void StopRotation()
    {
        isRotating = false;
    }

    void RotateTowardsTarget()
    {
        float step = rotationSpeed * Time.deltaTime;
        currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, step);
        targetObject.transform.rotation = Quaternion.Euler(currentRotation, targetObject.transform.rotation.eulerAngles.y, targetObject.transform.rotation.eulerAngles.z);

        if (Mathf.Approximately(currentRotation, targetRotation))
        {
            isRotating = false;
        }
    }
}
