using System;
using System.Globalization;
using Code.Meta.UI.GoldHolders.Service;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.GoldHolders.Behaviours
{
    public class GoldHolder : MonoBehaviour
    {
        public TextMeshProUGUI Amount;
        public TextMeshProUGUI Boost;

        private IStorageUIService _storageUIService;

        [Inject]
        private void Construct(IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
        }

        private void Start()
        {
            _storageUIService.GoldChanged += UpdateGold;
            _storageUIService.GoldBoostChanged += UpdateBoost;
        }

        private void OnDestroy()
        {
            _storageUIService.GoldChanged -= UpdateGold;
            _storageUIService.GoldBoostChanged -= UpdateBoost;
        }

        private void UpdateGold()
        {
            Amount.text = _storageUIService.CurrentGold.ToString(CultureInfo.InvariantCulture);
        }

        private void UpdateBoost()
        {
            float boost = _storageUIService.CurrentGoldGainBoost;

            switch (boost)
            {
                case > 0:
                    Boost.gameObject.SetActive(true);
                    Boost.text = boost.ToString("+0%");
                    break;
                
                default:
                    Boost.gameObject.SetActive(false);
                    break;
            }
        }
    }
}