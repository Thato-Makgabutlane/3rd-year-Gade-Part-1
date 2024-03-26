using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlag : MonoBehaviour
{
    [SerializeField] GameObject Hand;
    [SerializeField] GameObject Target;
    float distance;
    void Update()
    {
        distance = Vector3.Distance(transform.position,Target.transform.position);
        if (Input .GetKeyDown(KeyCode.E) && distance <= 3)
        {
            Target.GetComponent<BoxCollider>().enabled = false;
            GameManager.Instance.PlayerHasFlag();
            Target.transform.parent = Hand.transform;
            Target.transform.position = Hand.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.R) && distance <= 3)
        {
            Target.GetComponent<BoxCollider>().enabled = true;
            Target.transform.parent = null;
            Target.transform.position = transform.position;
        }
    }
}
