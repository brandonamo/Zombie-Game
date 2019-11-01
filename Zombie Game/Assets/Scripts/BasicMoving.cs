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
        //character = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 delta = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //character.SimpleMove(delta * MoveSpeed);

        float xAxisMovement = Input.GetAxis("Horizontal") * MoveSpeed;
        float zAxisMovement = Input.GetAxis("Vertical") * MoveSpeed;

        xAxisMovement *= Time.deltaTime;
        zAxisMovement *= Time.deltaTime;

        transform.Translate(xAxisMovement, 0, zAxisMovement);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }


    }
}
