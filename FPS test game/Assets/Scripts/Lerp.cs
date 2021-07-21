using UnityEngine;

public class Lerp : MonoBehaviour
{
    public Vector3 Lerping(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
