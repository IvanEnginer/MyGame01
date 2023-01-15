using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _mover.TryMoveUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _mover.TryMoveDown();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _mover.TryMoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _mover.TryMoveRight();
        }

        if (Input.GetMouseButtonDown(0))
        {
            _player.ShootWeaponOne();
        }


        if (Input.GetMouseButtonDown(1))
        {
            _player.ShootWeaponTwo();
        }
    }
}
