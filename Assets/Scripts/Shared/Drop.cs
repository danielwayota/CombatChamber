using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject dropPrefab;

    void Awake()
    {
        var health = GetComponent<Health>();

        health.OnDeath += this.SpawnItemOnDeath;
    }

    void SpawnItemOnDeath()
    {
        Instantiate(this.dropPrefab, this.transform.position, Quaternion.identity);
    }
}
