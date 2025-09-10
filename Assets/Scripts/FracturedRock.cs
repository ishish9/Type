using UnityEngine;

public class FracturedRock : MonoBehaviour
{
    private void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 25, 7);
        foreach (Collider target in colliders)
        {
            Rigidbody rb = target.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(400, transform.position, 25);
            }
        }
        Destroy(gameObject, 6);

    }
}
