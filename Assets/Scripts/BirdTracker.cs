using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird.Bird _bird;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var cameraPosition = transform.position;
        transform.position =
            new Vector3(_bird.transform.position.x - _xOffset, cameraPosition.y, cameraPosition.z);
    }
}
