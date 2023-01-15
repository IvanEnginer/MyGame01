using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _clashedToEnemy;
    [SerializeField] private Weapon _weaponOne;
    [SerializeField] private Weapon _weaponTwo;
    [SerializeField] private Transform _shootPoint;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ShootWeaponOne()
    {
        _weaponOne.Shoot(_shootPoint);
    }

    public void ShootWeaponTwo()
    {
        _weaponTwo.Shoot(_shootPoint);
    }

    public void ApplayDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

       _clashedToEnemy?.Invoke();

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Died.Invoke();
    }
}
