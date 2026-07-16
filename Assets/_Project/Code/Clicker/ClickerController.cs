using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Project.Code
{
    public class ClickerController : MonoBehaviour
    {
        [SerializeField] private Observer _observer;
        [SerializeField] private SkinController _skinController;
        
        [SerializeField] private TMP_Text _textScore;
        [SerializeField] private TMP_Text _textCompliment;
        
        [SerializeField] private Button _button;
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _buyButton;
        
        [SerializeField] private int _range = 100;
        [SerializeField] private string[] _compliments;
        
        private BankService _bankService;
        private int _lastPoint = 0;
        private int price = 100;

        private void Awake()
        {
            _bankService = _observer.GetBank();
            
            UpdateTextScore();
            
            _button.onClick.AddListener(UpdateScore);
            _resetButton.onClick.AddListener(ResetScore);
            _buyButton.onClick.AddListener(UpdateScorePerClick);
        }

        private void UpdateScorePerClick()
        {
            if (_bankService.GetScore() >= price)
            {
                _bankService.UpdateScorePerClick(price);
                UpdateTextScore();
            }
        }
        
        private void UpdateScore()
        {
            _bankService.SetScore();
            
            if (_bankService.GetScore() - _lastPoint >= _range)
            {
                ChangeColor();
                _textCompliment.SetText(_compliments[Random.Range(0, _compliments.Length - 1)]);
                _lastPoint += _range;
            }
            
            UpdateTextScore();
        }

        private void ChangeColor()
        {
            _skinController.ChangeColor();
        }

        private void ResetScore()
        {
            _bankService.ResetScore();
            UpdateTextScore();
        }
    
        private void UpdateTextScore()
        {
            _textScore.SetText($"${_bankService.GetScore().ToString()}");
        }
    
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(UpdateScore);
        }
    }
}

