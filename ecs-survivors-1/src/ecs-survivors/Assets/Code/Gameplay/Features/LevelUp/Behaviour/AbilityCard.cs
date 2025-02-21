using System;
using System.Collections;
using Code.Gameplay.Features.Abilities.Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviour
{
    public class AbilityCard : MonoBehaviour
    {
        public const float StampAnimTime = 1f;
        public AbilityTypeId Id;
        public Image Icon;
        public TextMeshProUGUI Description;
        public Button Button;
        public GameObject Stamp;
        
        private Action<AbilityTypeId> _onSelected;

        public void Setup(AbilityTypeId id, AbilityLevel abilityLevel, Action<AbilityTypeId> onSelected)
        {
            Id = id;
            Icon.sprite = abilityLevel.Icon;
            Description.text = abilityLevel.Description;

            _onSelected = onSelected;
            
            Button.onClick.AddListener(SelectCard);
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(SelectCard);
        }

        private void SelectCard()
        {
            StartCoroutine(StampAndReport());
        }

        private IEnumerator StampAndReport()
        {
            Stamp.SetActive(true);

            yield return new WaitForSeconds(StampAnimTime);
            
            _onSelected?.Invoke(Id);
        }
    }
}