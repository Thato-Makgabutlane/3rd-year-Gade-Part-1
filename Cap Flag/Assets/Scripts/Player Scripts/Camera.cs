using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]Transform player;
    Vector3 Offset = new Vector3(0,0.5f,0);
    
    void Update()
    {
        rot();
        transform.position = player.position + Offset;
    }
    void rot()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 0.7f, 0));
    }
}
