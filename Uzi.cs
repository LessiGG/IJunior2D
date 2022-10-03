using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class Uzi : Weapon
    {
        [SerializeField] private int _bulletsCount;
        [SerializeField] private float _fireRateDelay;
        
        public override void Shoot(Transform shootPoint)
        {
            StartCoroutine(UziShoot(shootPoint));
        }

        private IEnumerator UziShoot(Transform shootPoint)
        {
            var fireRateDelay = new WaitForSeconds(_fireRateDelay);

            for (int i = 0; i < _bulletsCount; i++)
            {
                Instantiate(Bullet, shootPoint.position, Quaternion.identity);
                yield return fireRateDelay;
            }
        }
    }
}