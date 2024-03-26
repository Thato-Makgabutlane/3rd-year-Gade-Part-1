using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer;
    [SerializeField] GameObject RespawnPoint;
    [SerializeField] GameObject PlayerRespawnPoint;
    private void Awake()
    {
        RespawnPoint = GameObject.FindGameObjectWithTag("AiSpawn");
        PlayerRespawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn");
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ai"))
        {
            if (collision.gameObject.transform.childCount > 1)
            {
                collision.gameObject.transform.GetChild(1).gameObject.tag = "Down";
                collision.gameObject.transform.GetChild(1).gameObject.transform.parent = null;
            }
            collision.gameObject.transform.position = RespawnPoint.transform.position;
            GameManager.Instance.AiNoFlag();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.transform.childCount >= 1)
            {
                if (collision.gameObject.transform.GetChild(0).gameObject.transform.childCount >= 2)
                {
                    collision.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.tag = "Dropped";
                    collision.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.parent = null;
                }
            }
            collision.gameObject.transform.position = PlayerRespawnPoint.transform.position;
            GameManager.Instance.PlayerNoFlag();
        }
    }
}
