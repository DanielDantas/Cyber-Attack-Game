using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
