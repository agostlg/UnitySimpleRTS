using System;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class WalletManager: MonoBehaviour
    {
        [SerializeField] public int coins;
        [SerializeField] private Text textUI;

        private void Start()
        {
            UpdateTextUI();
        }

        public void Increase(int amount)
        {
            coins += amount;
            UpdateTextUI();
        }
        
        public void Decrease(int amount)
        {
            coins -= amount;
            UpdateTextUI();
        }

        public bool CanAfford(int amount)
        {
            return coins - amount >= 0;
        }

        private void UpdateTextUI()
        {
            textUI.text = "" + coins;
        }
    }
}