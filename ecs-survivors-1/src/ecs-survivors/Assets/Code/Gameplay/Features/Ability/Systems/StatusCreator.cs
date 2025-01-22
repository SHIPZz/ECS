using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.TargetCollection;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class StatusCreator : MonoBehaviour
    {
        public float Cooldown = 6f;
        public LayerMask LayerMask;
        public float Radius = 1f;

        public List<StatusSetup> StatusSetups;

        private IIdentifierService _identifierService;

        [Inject]
        private void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        private void Start()
        {
            CreateEntity.Empty()
                .AddLayerMask(LayerMask)
                .AddWorldPosition(transform.position)
                .AddRadius(Radius)
                .AddStatusSetups(StatusSetups)
                .AddId(_identifierService.Next())
                .With(x => x.isStatusCreator = true)
                .With(x => x.isReadyToCollectTargets = true)
                .SetupTargetCollectionComponents(LayerMask)
                .With(x => x.AddCooldown(Cooldown))
                .PutOnCooldown()
                ;
        }
    }
}