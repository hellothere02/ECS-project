using Leopotam.Ecs;
//using UniversalMobileController;

public class InputSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<DirectionComponent, JoystickComponent> directionFilter = null;

    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    public void Init()
    {
        
    }

    public void Run()
    {
        SetDirection();

        foreach (var item in directionFilter)
        {
            ref var directionComponent = ref directionFilter.Get1(item);
            ref var direction = ref directionComponent.Direction;

            direction.x = horizontalInput;
            direction.z = verticalInput;
        }
    }

    private void SetDirection()
    {
        foreach (var item in directionFilter)
        {
            horizontalInput = directionFilter.Get2(item).JoyStick.GetHorizontalValue();
            verticalInput = directionFilter.Get2(item).JoyStick.GetVerticalValue();
        }
    }
}
