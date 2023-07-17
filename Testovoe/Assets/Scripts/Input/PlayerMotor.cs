using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    private float _speed = 5f;
    private bool _isGrounded;
    private float _gravity = -9.8f;
    private float _jumpHeight = 1.5f;

   

    private void Start()
    {
        if(Time.timeScale == 0f)
            Time.timeScale = 1f;

        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = _characterController.isGrounded;
    }

    public void MoveProcess(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _characterController.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);
        _playerVelocity.y += _gravity * Time.deltaTime;

        if (_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = -2f;

        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
        }
    }
}
