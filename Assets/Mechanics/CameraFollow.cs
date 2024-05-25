using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float minXClamp = -16.9f;
    public float maxXClamp = 100f;

    private void LateUpdate()
    {
        Vector3 cameraPos = transform.position;

        cameraPos.x = Mathf.Clamp(player.transform.position.x, minXClamp, maxXClamp);

        transform.position = cameraPos;
    }
}
