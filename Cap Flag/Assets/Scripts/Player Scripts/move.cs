using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float speed = 10f;
    [SerializeField] GameObject protectFlag;
    [SerializeField] GameObject flagbase;
    float distance;
    Vector3 Move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rot();
        distance = Vector3.Distance(transform.position, protectFlag.transform.position);
        if(protectFlag.CompareTag("Down") && distance <= 2.5)
        {
            protectFlag.transform.position = flagbase.transform.position;
            protectFlag.gameObject.tag = "Available";
        }
        Move = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        Move = transform.rotation * Move;
        rb.velocity = Move * speed;
    }
    void rot()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 0.7f, 0));
    }
}
