using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoring : MonoBehaviour
{
    [SerializeField] GameObject targetFlag;
    float distance;
    private void Update()
    {
        distance = Vector3.Distance(transform.position, targetFlag.transform.position);
        if (distance <= 3)
        {
            GameManager.Instance.AddPlayerScore();
            targetFlag.transform.parent = null;
            targetFlag.gameObject.tag = "Safe";
            GameManager.Instance.ResetLevel();
        }
    }
}
