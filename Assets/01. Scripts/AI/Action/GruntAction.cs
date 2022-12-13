using System.Collections.Generic;
using UnityEngine;

public class GruntAction : AIAction
{
    [SerializeField] List<PoolableMono> grunts = new List<PoolableMono>();

    [Header("Spawn Property")]
    [SerializeField] int maxGruntCount = 10;
    [SerializeField] float gruntSpawnDelay = 0.5f;

    private int currentGruntCount = 0;
    public int CurrentGruntCount => currentGruntCount;
    
    private float currentTimer = 0f;

    [Header("Spawn Position")]
    [SerializeField] Transform minPos = null;
    [SerializeField] Transform maxPos = null;

    public override void TakeAction()
    {
        if(currentGruntCount >= maxGruntCount)
            return;

        currentTimer += Time.deltaTime;

        if(currentTimer >= gruntSpawnDelay)
        {
            SpawnGrunt();

            currentGruntCount++;
            currentTimer = 0f;
        }
    }

    private void SpawnGrunt()
    {
        Vector3 spawnPos = GetRandomPos();

        PoolableMono grunt = grunts[Random.Range(0, grunts.Count)];
        if(grunt == null)
            return;

        grunt = PoolManager.Instance.Pop(grunt);
        grunt.transform.position = spawnPos;
    }

    private Vector3 GetRandomPos()
    {
        Vector3 randPos = Vector3.zero;
        randPos.x = Random.Range(minPos.position.x, maxPos.position.x);
        randPos.z = Random.Range(minPos.position.z, maxPos.position.z);
        randPos.y = minPos.position.y;

        return randPos;
    }
}
