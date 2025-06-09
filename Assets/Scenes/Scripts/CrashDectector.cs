using UnityEngine;

public class CrashDectector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) //Tag detection instead of mesh detection......
    {
        if (collision.collider.CompareTag("Wall"))
        {
            SFXManager.Instance.PlaySFX("crash");
            //Make sure sound references are in the SFX sound manager and naming conventions
            //Make sure auido folder is in place
        }
    }
}
