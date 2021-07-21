using UnityEngine;

public class TargetLerp : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    Lerp lerp;
    [SerializeField] [Range(0f, 4f)] float lerpTime;
    [SerializeField] public Vector3[] newPosition;
    Vector3 firstPos;
    float timeStartedLerping;
    int posIndex;
    int length;
    float t = 0f;

    void Awake()
    {
        firstPos = transform.position;
        lerp = gameManager.GetComponent<Lerp>();
        length = newPosition.Length;
    }
    private void Start() =>timeStartedLerping = Time.time;
    void FixedUpdate()
    {
        transform.position= lerp.Lerping(firstPos, newPosition[posIndex], timeStartedLerping, lerpTime);
        t += Time.deltaTime;
        if (t > lerpTime)
        {
            t = 0f;
            posIndex++;
            posIndex = (posIndex >= length) ? 0 : posIndex;
            firstPos = transform.position;
            timeStartedLerping = Time.time;
        }
    }
}
