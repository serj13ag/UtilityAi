using UnityEngine;

public class SceneContext : MonoBehaviour
{
    [SerializeField] private Transform _hotelTransform;
    [SerializeField] private Transform _resourceTransform;

    public Vector3 HotelPosition => new Vector3(_hotelTransform.position.x, 0f, _hotelTransform.position.z);
    public Vector3 ResourcePosition => new Vector3(_resourceTransform.position.x, 0f, _resourceTransform.position.z);
}