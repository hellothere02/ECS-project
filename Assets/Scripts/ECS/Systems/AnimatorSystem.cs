using Leopotam.Ecs;
using UnityEngine;

public class AnimatorSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<AnimatorComponent, DirectionComponent> animatorFilter = null;

    public void Run()
    {
        foreach (var item in animatorFilter)
        {
            ref var animator = ref animatorFilter.Get1(item);
            ref var direction = ref animatorFilter.Get2(item);

            Vector3 normalizedDirection = direction.Direction.normalized;
            float speed = Vector3.Dot(normalizedDirection, direction.Direction);

            animator.Animator.SetFloat("Speed_f", speed, 0.1f, Time.deltaTime);
        }
    }
}
