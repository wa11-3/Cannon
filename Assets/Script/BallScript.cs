using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float power;
    public float radius;
    public float upForce;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, radius, upForce);
                Debug.Log("Explote");
            }
        }
        //Destroy(gameObject);
    }
}
