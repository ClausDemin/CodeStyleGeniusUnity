using UnityEngine;

namespace Assets.CodeBase
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet: MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize(Vector3 direction)
        {
            transform.up = direction;
            _rigidbody.velocity = direction * _speed;
        }
    }
}
