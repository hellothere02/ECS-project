using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class GameStartup : MonoBehaviour
{
    [SerializeField] private ScriptableObject config;

    private EcsWorld world;
    private EcsSystems systems;

    private WheelsData wheelsData = new WheelsData();

    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems.ConvertScene();

        AddIjections();
        AddSystems();

        systems.Init();
    }

    private void AddIjections()
    {
        systems.Inject(config).Inject(wheelsData);
    }

    private void AddSystems()
    {
        systems.Add(new InputSystem()).Add(new MovementSystem()).Add(new AnimatorSystem()).
            Add(new WheelGeneratorSystem()).Add(new TakeAndGetSystem());
    }

    private void Update()
    {
        systems.Run();
    }

    private void OnDestroy()
    {
        if (systems == null) return;

        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;
    }
}


