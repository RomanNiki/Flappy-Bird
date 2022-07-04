using UnityEngine;

namespace Bird
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class BirdMover : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private float _speed;
        [SerializeField] private float _tapForce = 10f;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _minRotationZ;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
            ResetBird();
        }

        private void Update()
        {
            if (Time.timeScale < 1f)
            {
                return;
            }
            if (Input.GetButtonDown("Jump"))
            {
                _animator.SetTrigger("Fly");
                _rigidbody.velocity = new Vector2(_speed, 0);
                transform.rotation = _maxRotation;
                _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }

        public void ResetBird()
        {
            transform.position = _startPosition;
            transform.rotation = Quaternion.identity;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}