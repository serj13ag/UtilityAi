using System.Linq;
using Entities;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    [SerializeField] private Transform _hotelTransform;
    [SerializeField] private Resource[] _resources;

    public Vector3 HotelPosition => new Vector3(_hotelTransform.position.x, 0f, _hotelTransform.position.z);

    public Vector3 GetResourcePosition(ResourceType resourceType)
    {
        var resourcePosition = _resources.First(x => x.ResourceType == resourceType).transform.position;
        return new Vector3(resourcePosition.x, 0f, resourcePosition.z);
    }
}