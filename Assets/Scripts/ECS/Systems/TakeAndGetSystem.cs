using Leopotam.Ecs;
using UnityEngine;

public class TakeAndGetSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsFilter<ModelComponent> playerFilter = null;

    private WheelsData wheelsData = null;

    private int layerWheel = 6;
    private int layerCar = 7;
    private LayerMask layerMaskWheel;
    private LayerMask layerMaskCar;

    private bool isPickup = false;

    private GameObject wheel;

    public void Init()
    {
        layerMaskWheel = (1 << layerWheel);
        layerMaskCar = (1 << layerCar);
    }

    public void Run()
    {
        ref var position = ref playerFilter.Get1(0).Transform;

        if (Physics.CheckSphere(position.position, 2, layerMaskWheel) && isPickup == false)
        {
            GetWheel();
        }

        if (isPickup == true)
        {
            Carrying(wheel.transform, position);
        }

        if(Physics.CheckSphere(position.position, 2, layerMaskCar) && wheel != null)
        {
            wheel.gameObject.SetActive(false);
            wheel = null;
            isPickup = false;
            //RaycastHit hit;
            //if(Physics.Raycast(position.position, new Vector3(-position.position.x,1,0),out hit))
            //{
            //    Debug.Log("work");
            //    Debug.Log(hit.collider.name);
            //    if (hit.collider.CompareTag("cars"))
            //    {
            //        Debug.Log("work");
            //        wheel = null;
            //    }
            //}
        }
    }

    private void GetWheel()
    {
        wheel = wheelsData.GetWheel();
        isPickup = true;
    }

    private void Carrying(Transform _wheelPos, Transform _playerPos)
    {
        _wheelPos.position = new Vector3(_playerPos.position.x - 1, _playerPos.position.y + 2, _playerPos.position.z);
    }
}

