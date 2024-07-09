using Leopotam.Ecs;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;

public class WheelGeneratorSystem : IEcsInitSystem, IEcsDestroySystem
{
    private readonly EcsWorld _world = null;
    private readonly Config config = null;

    private WheelsData wheelsData = null;

    CancellationTokenSource token = new CancellationTokenSource();

    public void Init()
    {
        GenerateAsync(token.Token);
    }

    private async Task GenerateAsync(CancellationToken token)
    {
        await Task.Delay(TimeSpan.FromSeconds(3), token);
        Generate();
    }

    private void Generate()
    {
        GameObject wheel = UnityEngine.Object.Instantiate(config.WheelPrefab, 
            new Vector3(7, 0.5f + (wheelsData.WheelsCount()/2), -14), Quaternion.identity);
        wheelsData.AddWheel(wheel);
        GenerateAsync(token.Token);
    }

    public void Destroy()
    {
        token.Cancel();
    }
}
