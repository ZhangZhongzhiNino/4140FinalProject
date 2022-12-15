using UnityEngine;

namespace Root.Scripts.Adam.Puzzles
{
    public class PieceChecker : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool _state = false;
        [SerializeField] private bool correctState;
        private bool _isCorrect;
        
        public string InteractionPrompt { get; }
        public bool Interact(Interactor interactor)
        {
            _state = !_state;
            return true;
        }

        public bool PuzzleStateCheck()
        {
            Debug.Log("Puzzle State Checked");
            _isCorrect = _state.Equals(correctState);

            return _isCorrect;
        }
    }
}