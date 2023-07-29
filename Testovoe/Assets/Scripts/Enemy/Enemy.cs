using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    private float _speed = 3.0f;

    [Inject] public void Construct(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector3 targetPosition = _player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }
}
