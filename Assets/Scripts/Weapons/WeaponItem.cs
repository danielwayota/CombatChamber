using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    public GameObject weaponPrefab;

    private bool justDropped;

    // Start is called before the first frame update
    void Start()
    {
        this.justDropped = true;

        Invoke("ActivatePickUpMode", 1f);
    }

    private void ActivatePickUpMode()
    {
        this.justDropped = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.justDropped)
            return;

        WeaponManager manager = other.GetComponent<WeaponManager>();

        if (manager == null)
            return;

        if (manager.HasRoomForWeapon == false)
            return;

        var newWeapon = Instantiate(this.weaponPrefab);
        manager.PickUpWeapon(newWeapon.GetComponent<Weapon>());

        Destroy(this.gameObject);
    }
}
