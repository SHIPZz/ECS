using System.Collections.Generic;
using Code.Gameplay.Features.Armament.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public class ExplosiveEnchantSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _enchants;
        private readonly IArmamentFactory _armamentFactory;

        public ExplosiveEnchantSystem(IContext<GameEntity> game, IArmamentFactory armamentFactory) : base(game)
        {
            _armamentFactory = armamentFactory;
            _enchants = game.GetGroup(GameMatcher.AllOf(GameMatcher.ProducerId, GameMatcher.EnchantTypeId,GameMatcher.ExplosiveEnchant));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.AllOf(GameMatcher.Armament, GameMatcher.Reached).Added());

        protected override bool Filter(GameEntity entity) => entity.isArmament && entity.hasWorldPosition;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity enchant in _enchants)
            foreach (GameEntity armament in entities)
            {
                _armamentFactory.CreateExplosion(enchant.ProducerId, armament.WorldPosition);
            }
        }
    }

}