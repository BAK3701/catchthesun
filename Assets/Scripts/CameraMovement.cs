using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0F, 6.263f, 10.71f);
    private Vector3 cameraPos;
    // Start is called before the first frame update

    private void LateUpdate()
    {
        cameraPos = transform.position;
        cameraPos.x = 0f;
        cameraPos.y = offset.y;
        cameraPos.z = player.position.z + offset.z;
        transform.position = cameraPos;
    }
}
