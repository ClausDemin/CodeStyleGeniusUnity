using Assets.CodeBase;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileShooting : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;

    [SerializeField] private Transform _target;
    [SerializeField] float _cooldown;



    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        YieldInstruction awaitCooldown = new WaitForSeconds(_cooldown);

        while (isActiveAndEnabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.Initialize(direction);

            yield return awaitCooldown;
        }
    }
}