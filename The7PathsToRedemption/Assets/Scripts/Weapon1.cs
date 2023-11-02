using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float shootSpeed = 10f;
    [SerializeField] float ShotsPerSec = 2f;
    [SerializeField] bool mouseShoot = true;
    [SerializeField] float BulletDmg = 2f;
    [SerializeField] float BulletDestroy = 5f;
    [SerializeField] float Knockback = 1;

    [SerializeField] AudioClip PistolSND;
    [SerializeField] AudioClip HomingSND;
    [SerializeField] AudioClip ShotgunSND;
    [SerializeField] AudioClip BigGunSND;
    [SerializeField] AudioClip FastGunSND;

    float BulletTimeChecker = 1000f;
    float x = 1;
    float y = 0;
    [SerializeField] bool shootOn = true;
    [SerializeField] bool Pistol = false;
    [SerializeField] bool Homing = false;
    [SerializeField] bool Shotgun = false;
    [SerializeField] bool BigGun = false;
    [SerializeField] bool FastGun = false;
    bool FollowShots = false;
    void Update()
    {
        if (shootOn)
        {
            if (mouseShoot)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 shootDir = mousePosition - transform.position;
                shootDir.z = 0;
                shootDir.Normalize();
                x = shootDir.x;
                y = shootDir.y;
            }
            else
            {
                float tempX = Input.GetAxisRaw("Horizontal");
                float tempY = Input.GetAxisRaw("Vertical");
                if (tempX != 0 || tempY != 0)
                {
                    x = tempX;
                    y = tempY;
                }
            }
            if (Input.GetButton("Fire1"))
            {
                BulletTimeChecker += Time.deltaTime;
                if (BulletTimeChecker >= ShotsPerSec)
                {
                    BulletTimeChecker = 0;
                    GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * shootSpeed;
                    Destroy(bullet, BulletDestroy);
                }if (Homing)
                {
                    AudioSource.PlayClipAtPoint(HomingSND, Camera.main.transform.position);
                }else if (Shotgun)
                {
                    AudioSource.PlayClipAtPoint(ShotgunSND, Camera.main.transform.position);
                }else if (BigGun)
                {
                    AudioSource.PlayClipAtPoint(BigGunSND, Camera.main.transform.position);
                }else if (FastGun)
                {
                    AudioSource.PlayClipAtPoint(FastGunSND, Camera.main.transform.position);
                }else
                {
                    AudioSource.PlayClipAtPoint(PistolSND, Camera.main.transform.position);
                }
            }
        }
        if (Pistol)
        {
            ShotsPerSec = .4f;
            BulletDmg = 2f;
            Knockback = 1f;
            FollowShots = false;
        }
        else if (Homing)
        {
            ShotsPerSec = .5f;
            BulletDmg = 2f;
            Knockback = 2f;
            FollowShots = true;
        }else if (Shotgun)
        {
            ShotsPerSec = 1.5f;
            BulletDmg = 2.5f;
            Knockback = 6f;
            FollowShots = false;
        }
        else if (BigGun)
        {
            ShotsPerSec = .4f;
            BulletDmg = 8f;
            Knockback = 8f;
            FollowShots = false;
        }
        else if (FastGun)
        {
            ShotsPerSec = .2f;
            BulletDmg = 1f;
            Knockback = 0f;
            FollowShots = false;
        }
        else
        {
            shootOn = false;
        }
    }
}
