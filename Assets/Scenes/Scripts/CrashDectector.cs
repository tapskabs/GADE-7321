using UnityEngine;

public class CrashDectector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            SFXManager.Instance.PlaySFX("crash");
        }
    }
}
