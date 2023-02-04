using UnityEngine;

public class Pivot : MonoBehaviour
{
    private const float MaxAngle = 75.0f;

    private float currentAngle;
    private float currentTargetAngle;

    private float velocity = 0.0f;
    private const float smoothTime = 1.81f;

    private void Start()
    {
        currentTargetAngle = Random.Range(0, 100) > 50 ? MaxAngle : -MaxAngle;
        currentAngle = -currentTargetAngle;
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }

    private void Update()
    {
        currentAngle = Mathf.SmoothDamp(currentAngle, currentTargetAngle, ref velocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);

        if(Mathf.Abs(currentTargetAngle - currentAngle) < 1.5f)
        {
            currentTargetAngle *= -1;
        }
    }
}
