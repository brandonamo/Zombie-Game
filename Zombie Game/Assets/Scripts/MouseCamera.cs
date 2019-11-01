using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

    }
}
