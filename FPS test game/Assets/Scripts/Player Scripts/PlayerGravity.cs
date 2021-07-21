using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 2;
    Rigidbody _rigidbody;
    private void Awake()=>_rigidbody = GetComponent<Rigidbody>();
    
    public void Jump()
    {
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
