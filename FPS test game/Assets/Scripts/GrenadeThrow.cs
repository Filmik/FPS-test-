using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    [SerializeField]
    GameObject grenade;
    [SerializeField]
    int maxAmmo = 3;
    [SerializeField]
    int currentAmmo = 0;
    [SerializeField]
    float throwForce = 40f;
    [SerializeField]
    GameObject grenadePrefab;
    [SerializeField]
    Camera mainCamera;
    void Awake()
    {
        currentAmmo = maxAmmo;
    }
    public void ThrowGrenade()
    {
        if (grenade.activeSelf&&currentAmmo>0) 
        {
            GameObject newGrenade= Instantiate(grenadePrefab, grenade.transform.position, transform.rotation);
            Rigidbody rb = newGrenade.GetComponent<Rigidbody>();
            rb.AddForce(mainCamera.transform.forward *throwForce);
            currentAmmo--;
        }
    }
}
