using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnEnable()
    {
        Invoke("Deactivate", 10f);
    }

    void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.ProjectileImpact);

        GameObject impactEffect = ObjectPool.instance.GetPooledObject3();
        if (impactEffect != null)
        {
            impactEffect.transform.position = transform.position;
            impactEffect.SetActive(true);
        }

        gameObject.SetActive(false);
    }


    private void Deactivate()
    {
        //yield return new WaitForSeconds(6);

        gameObject.SetActive(false);
    }
}
