using System;
using UnityEngine;

namespace Project.Code
{
    [DefaultExecutionOrder(-100)]
    public class Observer : MonoBehaviour
    {
        private BankService _bankService;
        
        private void Awake()
        {
            _bankService = new BankService(0);
        }

        public BankService GetBank()
        {
            return _bankService;
        }
    }
}


