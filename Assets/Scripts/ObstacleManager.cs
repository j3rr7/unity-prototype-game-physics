using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManager playerManager = collision.gameObject.GetComponent<PlayerManager>();

            if (playerManager != null)
            {
                playerManager.ApplyDamage(100f);
            }
        }
    }
}
