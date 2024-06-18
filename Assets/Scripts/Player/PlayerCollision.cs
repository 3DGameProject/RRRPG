using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Vector3 scaleIncrease = new Vector3(1.1f, 1.1f, 1.1f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collisionable"))
        {
            transform.localScale = Vector3.Scale(transform.localScale, scaleIncrease);
            Destroy(other.gameObject);
        }
    }
}
