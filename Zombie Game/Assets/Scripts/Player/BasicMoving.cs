using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoving : MonoBehaviour
{
    public float MoveSpeed = 5.0F;
    CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.Paused)
        {
            float xAxisMovement = Input.GetAxis("Horizontal") * MoveSpeed;
            float zAxisMovement = Input.GetAxis("Vertical") * MoveSpeed;

            Vector3 targetDirection = new Vector3(xAxisMovement, 0f, zAxisMovement);
            targetDirection = transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            character.SimpleMove(targetDirection);
        }
    }
}
