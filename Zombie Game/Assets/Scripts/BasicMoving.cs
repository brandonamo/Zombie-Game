using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoving : MonoBehaviour
{
    public float MoveSpeed;
    CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.SimpleMove(delta * MoveSpeed);
    }
}
