using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Code
{
    public class ClickerController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textScore;
        [SerializeField] private Button _button;
        [SerializeField] private Button _resetButton;
        [SerializeField] private int _score = 30;
    
        private int _scoreValue;

        private void Awake()
        {
            UpdateTextScore();
            _button.onClick.AddListener(UpdateScore);
            _resetButton.onClick.AddListener(ResetScore);
        }
    

        private void UpdateScore()
        {
            _scoreValue += _score;
            UpdateTextScore();
        }
    
        private void ResetScore()
        {
            _scoreValue = 0;
            UpdateTextScore();
        }
    
        private void UpdateTextScore()
        {
            _textScore.SetText($"${_scoreValue.ToString()}");
        }
    
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(UpdateScore);
        }
    }
}

