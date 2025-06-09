using UnityEngine;

public class CrashDectector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) //Tag detection instead of mesh detection......
    {
        if (collision.collider.CompareTag("Wall"))
        {
            SFXManager.Instance.PlaySFX("crash");
        }
    }
}
