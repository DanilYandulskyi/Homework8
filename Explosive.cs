using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ColorSeter))]
public class Explosive : Spawner<Explosive>
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
   
    private List<Explosive> _clones = new List<Explosive>();
    private int _spawnChance = 100;
    private int _maxSpawningExplosiveCount = 6;
    private int _minSpawningExplosiveCount = 2;
    private int _dividedCoefficient = 2;

    private void OnMouseDown()
    {
        Explode();
    }

    private void Explode()
    {
        foreach (Collider collider in GetColliders())
        {
            for (int i = 0; i < _clones.Count; i++)
            {
                if (collider.gameObject == _clones[i])
                    collider.attachedRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }

        if (ChanceGenerator.CheckChance(_spawnChance))
            SpawnExplosive();

        Destroy(gameObject);
    }

    private void SpawnExplosive()
    {
        int spawningExplosiveCount = Random.Range(_minSpawningExplosiveCount, _maxSpawningExplosiveCount);
        
        for (int i = 0; i < spawningExplosiveCount; i++)
        {
            Explosive clone = Spawn();
            clone._spawnChance /= _dividedCoefficient;
            clone.transform.localScale /= _dividedCoefficient;
            _clones.Add(clone);
        }
    }

    private Collider[] GetColliders()
    {
        return Physics.OverlapSphere(transform.position, _explosionRadius);
    }
}