using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameManager.Instance.GameStop();

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameManager.Instance.GameStop();
    }
}
