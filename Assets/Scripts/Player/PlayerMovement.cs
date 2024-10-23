using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    private CharacterController _controller;
    private Vector3 _velocity;
    private Animator _animator;
    private float _speed;
    private float _gravity = -9.81f;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _speed = 3f;
        _controller = GetComponent<CharacterController>();
    }


    public void Move()
    {
        
        float x = _joystick.Horizontal;
        float z = _joystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * _speed * Time.deltaTime);
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        if (move == Vector3.zero)
        {
            _animator.SetBool("isMove", false);
        }
        else
        {
            _animator.SetBool("isMove", true);

        }
    }

    private void Update()
    {
        Move();
    }

}
