using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBulletSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform spawnPoint;

    public void SpawnBullet()
    {
        Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
