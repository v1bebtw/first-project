using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Project.Code
{
    public class SkinController : MonoBehaviour
    {
        [SerializeField] private Observer _observer;
        [SerializeField] private Image _imageBG;     
        [SerializeField] private ColorItem[] _colorItems;

        private BankService _bankService;
        
        private void Awake()
        {
            _bankService = _observer.GetBank();
            ChangeColor();
        }

        public void ChangeColor()
        {
            _imageBG.color = _colorItems[Random.Range(0, _colorItems.Length - 1)].color;
        }
    }
}