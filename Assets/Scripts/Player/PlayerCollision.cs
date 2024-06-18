using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //public GameObject player;
    public Vector3 scaleIncrease = new Vector3(1.1f, 1.1f, 1.1f);

    private PlayerCondition condition;

    private void Awake()
    {
        condition = GetComponent<PlayerCondition>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collisionable"))
        {
            condition.isCollision = true;
            transform.localScale = Vector3.Scale(transform.localScale, scaleIncrease);
            Destroy(other.gameObject);
        }
    }
}
