using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Project.Code
{
    public class SkinController : MonoBehaviour
    {
        [SerializeField] private Image _imageBG;     
        [SerializeField] private ColorItem[] _colorItems;

        private void Awake()
        {
            _imageBG.color = _colorItems[Random.Range(0, _colorItems.Length) - 1].color;
        }
    }
}