using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShoot : MonoBehaviour
{
    public Transform firePoint;
    public Transform spider;
    private Transform target;

    public GameObject bulletprefab;
    public GameObject player;

    public float range = 60f;
    public float fireRate = 0.5f;

    private float fireCountdown = 2;

    public string playerTag = "Player";

    void Start()
    {
        //Function is called two times per second
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= range)
            target = player.transform;
        else target = null;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(spider.rotation, lookRotation, Time.deltaTime * 2).eulerAngles;
        spider.rotation = Quaternion.Euler(-90f, rotation.y, 0f);

        if(fireCountdown<=0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletprefab, firePoint.position, firePoint.rotation);

        SpiderBullet bullet = bulletGO.GetComponent<SpiderBullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
