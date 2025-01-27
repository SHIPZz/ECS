using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.TargetCollection;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Features.Pull.Systems
{
    public class PullTestView : MonoBehaviour
    {
        public int MaxPullTargets = 5;
        public int MinPullTargets = 1;
        public CollisionLayer Layer;
        public float PullInRadius = 3f;
        public List<StatusSetup> StatusSetups;
        private IIdentifierService _identifierService;

        [SerializeField] private float _createTime;

        public LootTypeId LootTypeId;

        [SerializeField] private float _lastTime;
        private ILootFactory _lootFactory;

        [Inject]
        private void Construct(IIdentifierService identifierService, ILootFactory lootFactory)
        {
            _lootFactory = lootFactory;
            _identifierService = identifierService;
        }

        private void Awake()
        {
            CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddMinCountToPullTargets(MinPullTargets)
                .AddTargetsBuffer(new List<int>(32))
                .AddPullTargetLayerMask(Layer.AsMask())
                .AddPullInRadius(PullInRadius)
                .AddStatusSetups(new List<StatusSetup>())
                .With(x => x.AddStatusSetups(StatusSetups))
                .AddWorldPosition(transform.position)
                .With(x => x.AddPullTargetList(new List<int>(32)))
                .With(x => x.isPullingDetector = true)
                .With(x => x.isPullTargetHolder = true)
                ;
        }

        private void Start()
        {
            Vector2 randomOffset = Random.insideUnitCircle * 15f;
            Vector3 spawnPosition = new Vector3(
                transform.position.x + randomOffset.x,
                transform.position.y,
                transform.position.z + randomOffset.y
            );
            _lootFactory.CreateLootItem(LootTypeId, spawnPosition);
        }

        private void Update()
        {
            if (_createTime == 0)
                return;

            _lastTime += Time.deltaTime;

            if (_lastTime >= _createTime)
            {
                Vector2 randomOffset = Random.insideUnitCircle * 15f;
                Vector3 spawnPosition = new Vector3(
                    transform.position.x + randomOffset.x,
                    transform.position.y,
                    transform.position.z + randomOffset.y
                );

                _lootFactory.CreateLootItem(LootTypeId, spawnPosition);
                _lastTime = 0f;
            }
        }
    }
}