using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider collision)
    {        
        Destroy(gameObject);
    }
}