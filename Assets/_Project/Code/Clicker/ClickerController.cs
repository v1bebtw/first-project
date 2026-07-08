using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Code
{
    public class ClickerController : MonoBehaviour
    {
        [SerializeField] private SkinController _skinController;
        [SerializeField] private TMP_Text _textScore;
        [SerializeField] private TMP_Text _textOfCompliment;
        [SerializeField] private Button _button;
        [SerializeField] private Button _resetButton;
        [SerializeField] private int _score = 30;
        [SerializeField] private string[] _compliments;
    
        private int _scoreValue;
        private int _lastTrigger = 0;

        private void Awake()
        {
            UpdateTextScore();
            _button.onClick.AddListener(UpdateScore);
            _resetButton.onClick.AddListener(ResetScore);
        }
    

        private void UpdateScore()
        {
            _scoreValue += _score;
            
            if (_scoreValue - _lastTrigger >= 100)
            {
                ChangeColor();
                ChangeText();
                _lastTrigger += 100;
            }
            
            UpdateTextScore();
        }

        private void ChangeText()
        {
            _textOfCompliment.SetText(_compliments[Random.Range(0, _compliments.Length - 1)]);
        }

        private void ChangeColor()
        {
            _skinController.ChangeColor();
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

