using Leopotam.Ecs;
using UnityEngine;

sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> movableFilter = null;
    private readonly EcsFilter<ModelComponent>.Exclude<MovableComponent> rotationFilter = null;

    public void Run()
    {
        foreach (var item in movableFilter)
        {
            ref var modelComponent = ref movableFilter.Get1(item);
            ref var movableComponent = ref movableFilter.Get2(item);
            ref var directionComponent = ref movableFilter.Get3(item);

            ref var direction = ref directionComponent.Direction;
            ref var transform = ref modelComponent.Transform;

            ref var speed = ref movableComponent.Speed;

            transform.Translate(Vector3.forward.normalized * direction.x * speed * Time.deltaTime);
            transform.Translate(Vector3.right.normalized * -direction.z * speed * Time.deltaTime);


            if (direction != Vector3.zero)
            {
                ref var rotationModelComponent = ref rotationFilter.Get1(item);
                ref var rotationModel = ref rotationModelComponent.Transform;

                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                rotationModel.rotation = Quaternion.RotateTowards(rotationModel.rotation, toRotation, speed * 100 * Time.deltaTime);
            }
        }
    }
}
