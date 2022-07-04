using Pipe;
using UnityEngine;

namespace Bird
{
    [RequireComponent(typeof(Bird))]
    public class BirdColliderHandler : MonoBehaviour
    {
        private Bird _bird;

        private void Start()
        {
            _bird = GetComponent<Bird>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<ScoreZone>(out _))
            {
                _bird.IncreaseScore();
            }
            else
            {
                _bird.Die();
            }
        }
    }
}
