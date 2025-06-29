using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileShooting : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] public float _bulletSpeed;

    [SerializeField] private Transform _target;
    [SerializeField] float _cooldown;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (isActiveAndEnabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _bulletSpeed;

            yield return new WaitForSeconds(_cooldown);
        }
    }
}