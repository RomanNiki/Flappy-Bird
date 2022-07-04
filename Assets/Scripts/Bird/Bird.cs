using UnityEngine;
using UnityEngine.Events;

namespace Bird
{
    [RequireComponent(typeof(BirdMover))]
    public class Bird : MonoBehaviour
    {
        private BirdMover _birdMover;
        private int _score;
        
        public event UnityAction GameOver;
        public event UnityAction<int> ScoreChanged;
        private void Start()
        {
            _birdMover = GetComponent<BirdMover>();
        }

        public void ResetPlayer()
        {
            _score = 0;
            _birdMover.ResetBird();
            ScoreChanged?.Invoke(_score);
        }

        public void Die()
        {
            GameOver?.Invoke();
        }

        public void IncreaseScore()
        {
            _score++;
            ScoreChanged?.Invoke(_score);
        }
    }
}
