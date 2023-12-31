using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon1 : MonoBehaviour
{
    [SerializeField] GameObject prefabp;
    [SerializeField] GameObject prefabh;
    [SerializeField] GameObject prefabs;
    [SerializeField] GameObject prefabb;
    [SerializeField] GameObject prefabf;

    [SerializeField] float shootSpeed = 10f;
    [SerializeField] float ShotsPerSec = 2f;
    [SerializeField] bool mouseShoot = true;
    [SerializeField] public float BulletDmg = 2f;
    [SerializeField] float BulletDestroy = 5f;

    [SerializeField] AudioClip PistolSND;
    [SerializeField] AudioClip HomingSND;
    [SerializeField] AudioClip ShotgunSND;
    [SerializeField] AudioClip BigGunSND;
    [SerializeField] AudioClip FastGunSND;

    float BulletTimeChecker = 1f;
    float x = 1;
    float y = 0;
    [SerializeField] public bool shootOn = true;
    [SerializeField] public bool Pistol = false;
    [SerializeField] public bool Homing = false;
    [SerializeField] public bool Shotgun = false;
    [SerializeField] public bool BigGun = false;
    [SerializeField] public bool FastGun = false;
    bool FollowShots = false;

    int PistLVL = 0;
    int HomLVL = 0;
    int ShoLVL = 0;
    int BigLVL = 0;
    int FastLVL = 0;
    void Update()
    {
        BulletTimeChecker += Time.deltaTime;
        Pistol = FindObjectOfType<GameSession>().Pistol;
        Homing = FindObjectOfType<GameSession>().Homing;
        Shotgun = FindObjectOfType<GameSession>().Shotgun;
        BigGun = FindObjectOfType<GameSession>().BigGun;
        FastGun = FindObjectOfType<GameSession>().FastGun;

        if (shootOn)
        {
            if (mouseShoot)
            {
                Vector3 mousePosition;
                Vector2 temp = new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue());
                mousePosition = Camera.main.ScreenToWorldPoint(temp);
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
                   // x = tempX;
                   // y = tempY;
                }
            }
            PistLVL = FindObjectOfType<GameSession>().pLevel;
            HomLVL = FindObjectOfType<GameSession>().hLevel;
            ShoLVL = FindObjectOfType<GameSession>().sLevel;
            BigLVL = FindObjectOfType<GameSession>().bLevel;
            FastLVL = FindObjectOfType<GameSession>().fLevel;
        }
        if (Pistol)
        { 
            ShotsPerSec = .4f;
            BulletDmg = 2f + PistLVL;
            FollowShots = false;
            shootOn = true;
        }
        else if (Homing)
        {
            ShotsPerSec = .5f;
            BulletDmg = 2f + HomLVL;
            FollowShots = true;
            shootOn = true;
        }
        else if (Shotgun)
        {
            ShotsPerSec = 1.5f;
            BulletDmg = 3f + ShoLVL;
            FollowShots = false;
            shootOn = true;
        }
        else if (BigGun)
        {
            ShotsPerSec = 2f;
            BulletDmg = 6f + BigLVL;
            FollowShots = false;
            shootOn = true;
        }
        else if (FastGun)
        {
            ShotsPerSec = .2f;
            BulletDmg = 1f + FastLVL;
            FollowShots = false;
            shootOn = true;
        }
        else
        {
            shootOn = false;
        }
    }
    void OnFire(InputValue value)
    {
        if (shootOn == true)
        {
            if (BulletTimeChecker >= ShotsPerSec)
            {
                if (Pistol)
                {
                    BulletTimeChecker = 0;
                    GameObject bullet = Instantiate(prefabp, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * shootSpeed;
                    Destroy(bullet, BulletDestroy);
                }
                if (Homing)
                {
                    BulletTimeChecker = 0;
                    GameObject bullet = Instantiate(prefabh, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * shootSpeed;
                    Destroy(bullet, BulletDestroy);
                }
                if (Shotgun)
                {
                    BulletTimeChecker = 0;
                    GameObject bullet = Instantiate(prefabs, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * shootSpeed;
                    Destroy(bullet, BulletDestroy);
                }
                if (BigGun)
                {
                    BulletTimeChecker = 0;
                    GameObject bullet = Instantiate(prefabb, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * shootSpeed;
                    Destroy(bullet, BulletDestroy);
                }
                if (FastGun)
                {
                    BulletTimeChecker = 0;
                    GameObject bullet = Instantiate(prefabf, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * shootSpeed;
                    Destroy(bullet, BulletDestroy);
                }

            }
            if (Homing)
            {
                AudioSource.PlayClipAtPoint(HomingSND, Camera.main.transform.position);
            }
            else if (Shotgun)
            {
                AudioSource.PlayClipAtPoint(ShotgunSND, Camera.main.transform.position);
            }
            else if (BigGun)
            {
                AudioSource.PlayClipAtPoint(BigGunSND, Camera.main.transform.position);
            }
            else if (FastGun)
            {
                AudioSource.PlayClipAtPoint(FastGunSND, Camera.main.transform.position);
            }
            else
            {
                AudioSource.PlayClipAtPoint(PistolSND, Camera.main.transform.position);
            }
        }
    }
    private void OnMove(InputValue value)
    {
        if (value.Get<Vector2>().magnitude != 0 && !mouseShoot)
        {
            x = value.Get<Vector2>().x;
            y = value.Get<Vector2>().y;
        }
    }
}
