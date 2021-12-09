using Leopotam.Ecs;
using UnityEngine;

public struct Weapon
{
    public EcsEntity owner;
    public PollObjects.ObjectInfo.ObjectType bullet;
    public Transform projectileSocket;
    public float projectileSpeed;
    public float projectileRadius;
    public int weaponDamage;
    public int currentInMagazine;
    public int maxInMagazine;
    public int totalAmmo;
    public float scater;
    public float pellet;
}