using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;

    public void Shoot() {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
