using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapon
{
    public Transform spawn;

    protected override void shootWeapon(){
        if (socket != null && socket.selectTarget != null){
            base.shootWeapon();
            RaycastHit hit;

            if (Physics.Raycast(spawn.position, spawn.forward, out hit)){
                if (hit.collider != null){
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null){
                        enemyHealth.TakeDamage(bulletDamage);
                    }
                }
            }
        }
    }

    protected override void onDeactive(XRBaseInteractor interactor){
        base.onDeactive(interactor);
    }

    protected override void onActive(XRBaseInteractor interactor){
        shootWeapon();
    }
}
