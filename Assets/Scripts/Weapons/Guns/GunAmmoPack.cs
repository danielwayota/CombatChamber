using UnityEngine;

public class GunAmmoPack : MonoBehaviour
{
    public GunType type;
    public int amount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var weaponManager = other.gameObject.GetComponent<WeaponManager>();
        if (weaponManager == null)
        {
            return;
        }

        if (weaponManager.TryToRecharge(this.type, this.amount))
        {
            Destroy(this.gameObject);
        }
    }
}
