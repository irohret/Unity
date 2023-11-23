using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extra : MonoBehaviour
{

}

/// Riffle : Weapon 
/*
public class Rifle : Weapon
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private float fireRate;
    public Transform spawnPoint;

    // EnemyHealth = enemy;

    public float recoil = 0.0f;
    private bool isShooting = false;

    
    void shootWeapon(){
        if (socket != null && socket.selectTarget != null){
            base.shootWeapon();
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            bullet.GetComponent<Collition>().SetDamage(bulletDamage); // Pass the bulletDamage to the bullet
            bullet.GetComponent<Rigidbody>().velocity = launchForce * spawnPoint.forward;
            Destroy(bullet, 5f);
            UpdateInfo(); 
        }
    }

        void shootWeapon(){
        if (socket != null && socket.selectTarget != null){
            base.shootWeapon();
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = launchForce * spawnPoint.forward;
            Destroy(bullet, 5f);
            UpdateInfo(); 
        }
    }

    private IEnumerator AutoShoot() {
        while (!isShooting && magazineSize > 0){
            shootWeapon();
            yield return new WaitForSeconds(1 / fireRate);
        }
    }

    protected override void onDeactive(XRBaseInteractor interactor){
        base.onDeactive(interactor);
        if(socket.selectTarget == null){
            ResetMagazine();
        }
        
        StopAllCoroutines();
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(bulletDamage);
            Destroy(gameObject); // Destroy the bullet on impact
        }
    }

    protected override void onActive(XRBaseInteractor interactor){
        if (socketObject != null){
            shootWeapon();
            UpdateInfo();
        }
        StartCoroutine(AutoShoot());
    }
}*/

// Pistol : Weapon 
/*
public class Pistol : Weapon
{
    [SerializeField] GameObject bulletPrefab;
    public Transform spawn;
    // [SerializeField] private float launchForce = 25f;
    public float recoil = 0.0f;

    protected override void shootWeapon(){
        if (socket != null && socket.selectTarget != null){
            base.shootWeapon();
            GameObject bullet = Instantiate(bulletPrefab, spawn.position, spawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = launchForce * spawn.forward;
            Destroy(bullet, 5f);
        }
    }

    protected override void onDeactive(XRBaseInteractor interactor){
        base.onDeactive(interactor);
    }

    protected override void onActive(XRBaseInteractor interactor){
        shootWeapon();
    }
}*/

// Weapon Class : Mono
/*public class Weapon : MonoBehaviour
{
    public int bulletDamage;
    [Range(0, 10f)] public float recoilAmount;
    [SerializeField] public float launchForce = 5f;
    public Rigidbody rb;
    private XRGrabInteractable interactable;
    public XRSocketInteractor socket;
    public GameObject socketObject;
    [Range(0, 999)] public int magazineSize;
    [Range(0, 10)] public int magazineAmount = 1;
    public TMP_Text text_pro;

    private void Start(){
        socket = socketObject.GetComponent<XRSocketInteractor>();
        interactable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        interactable.onSelectEntered.AddListener(onPickUp);
        interactable.onSelectExited.AddListener(onDrop);

        interactable.onActivate.AddListener(onActive);
        interactable.onDeactivate.AddListener(onDeactive);

        text_pro = GetComponentInChildren<TMP_Text>(); 
    }

    public void UpdateInfo(){
        if (magazineSize > 0 && socket.selectTarget != null){
            magazineSize--;
            text_pro.text = magazineSize.ToString();
        } 
    }

    public void ResetMagazine(){   
        magazineSize = 35;
        text_pro.text = magazineSize.ToString();
    }


    private void onPickUp(XRBaseInteractor interactor)
    {
        // Debug.Log("Object has been picked up");
    }

    private void onDrop(XRBaseInteractor interactor)
    {
        // Debug.Log("Object has been set down");
    }

    protected virtual void onActive(XRBaseInteractor interactor)
    {
        // Debug.Log("Trigger has been pressed");
    }

    protected virtual void onDeactive(XRBaseInteractor interactor)
    {
        // Debug.Log("Trigger has been released");
    }


    protected virtual void shootWeapon()
    {
        recoil();
    }

    private void recoil()
    {
        Debug.Log("Recoil!");
        rb.AddRelativeForce(Vector3.back * recoilAmount, ForceMode.Impulse);
    }
}*/
