using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private UnityEvent _diedVFX;
    [SerializeField] private int _dieDelayFraim = 255;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplayDamage(_damage);
        }

        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        _diedVFX?.Invoke();

        for (int i = 0; i < _dieDelayFraim; i++)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
