using System.Collections.Generic;
using UnityEngine;

public class GruntAction : AIAction
{
    [SerializeField] bool gruntOnly = true;

    [Space(10f)]
    [SerializeField] List<PoolableMono> grunts = new List<PoolableMono>();

    [Header("Spawn Property")]
    [SerializeField] int maxGruntCount = 10;
    [SerializeField] float gruntSpawnDelay = 0.5f;

    private int currentGruntCount = 0;
    public int CurrentGruntCount { get => currentGruntCount; set => currentGruntCount = value; }
    
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

        PoolableMono temp = grunts[Random.Range(0, grunts.Count)];
        if(temp == null)
            return;

        if(gruntOnly)
        {
            Grunt grunt = PoolManager.Instance.Pop(temp) as Grunt;
            grunt.Init(spawnPos, this);
        }
        else
            PoolManager.Instance.Pop(temp).transform.position = spawnPos;
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
