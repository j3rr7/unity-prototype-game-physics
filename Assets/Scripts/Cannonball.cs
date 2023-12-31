using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Cannonball collided with " + collision.gameObject.name); // Debug log
        StartCoroutine(DeleteObjectAfterDelay(gameObject));

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager playerManager = collision.gameObject.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                playerManager.ApplyDamage(100f);
            }
        }
    }

    private IEnumerator DeleteObjectAfterDelay(GameObject objectToDelete)
    {
        yield return new WaitForSeconds(2);
        Destroy(objectToDelete);
    }
}
