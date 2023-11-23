using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Rifle : Weapon
{
    [SerializeField] private float fireRate;
    public Transform spawnPoint;
    private bool isShooting = false;

    void shootWeapon(){
        if (socket != null && socket.selectTarget != null){
            base.shootWeapon();
            RaycastHit hit;
            
            GameObject cartridge = Instantiate(bulletCartridge, cartridgeDischarge.position, cartridgeDischarge.rotation);
            cartridge.GetComponent<Rigidbody>().velocity = launchForce * cartridgeDischarge.forward;
            Destroy(cartridge, 3f);

            TrailRenderer trail = Instantiate(bulletTrailPrefab, spawnPoint.position, spawnPoint.rotation);

            // muzzleParticlele.Play();
            StartCoroutine(SpawnTrail(bulletTrailPrefab, spawnPoint.position + spawnPoint.forward * 100f));

            if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit)){
                
                if (hit.collider != null){
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null){
                        enemyHealth.TakeDamage(bulletDamage);
                    }
                }
            }
            UpdateInfo();
        }
    }

    private IEnumerator AutoShoot(){
        while (!isShooting && magazineSize > 0) {
            shootWeapon();
            yield return new WaitForSeconds(2 / fireRate);
        }
    }

    protected override void onDeactive(XRBaseInteractor interactor) {
        base.onDeactive(interactor);
        // muzzleParticlele.Stop();
        if (socket.selectTarget == null){
            ResetMagazine();
        }

        StopAllCoroutines();
    }

    protected override void onActive(XRBaseInteractor interactor){
        if (socketObject != null){
            shootWeapon();
            UpdateInfo();
        }

        StartCoroutine(AutoShoot());
    }

    // TrailRenderer 
    private IEnumerator SpawnTrail(TrailRenderer trailPrefab, Vector3 hitPoint){
        TrailRenderer trail = Instantiate(trailPrefab, spawnPoint.position, spawnPoint.rotation);
        float time = 0;

        Vector3 startPoint = trail.transform.position;

        while (time < 1){
            trail.transform.position = Vector3.Lerp(startPoint, hitPoint, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }

        trail.transform.position = hitPoint;
        Destroy(trail.gameObject, trail.time);
    }

}


