using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 1;
    private Vector2 movement;
    Vector3 move;
    void Update()
    {
        if (movement != Vector2.zero)
        {
            move = transform.right * movement.x + transform.forward * movement.y;
            transform.position += move * Time.deltaTime * movementSpeed;
        }
    }
    public void GetMoveVector(Vector2 inputMovement) => movement = inputMovement;
}
