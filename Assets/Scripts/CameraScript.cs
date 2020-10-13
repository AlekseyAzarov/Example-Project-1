using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        transform.position = Vector3.LerpUnclamped(transform.position, player.transform.position, 0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
