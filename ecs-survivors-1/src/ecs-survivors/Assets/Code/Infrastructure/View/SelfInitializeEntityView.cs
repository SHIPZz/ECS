using System;
using Code.Common.Entity;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class SelfInitializeEntityView : MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;
        private IIdentifierService _identifierService;

        [Inject]
        private void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        private void Awake()
        {
            EntityBehaviour.SetEntity(CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
            );
        }
    }
}