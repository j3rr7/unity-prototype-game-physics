using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cannonBallPrefab;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float force = 1f;

    void Start()
    {
        StartCoroutine(ShootCannonball());
    }

    private IEnumerator ShootCannonball()
    {
        while (true)
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = cannonBall.GetComponent<Rigidbody>();

            Vector3 direction = firePoint.transform.forward;
            rb.AddForce(direction.normalized * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}
