using System.Collections.Generic;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public class HexEnchantSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enchants;
        private readonly IGroup<GameEntity> _armaments;
        private readonly List<GameEntity> _buffer = new(32);
        private readonly List<GameEntity> _buffer2 = new(32);
        private readonly IStaticDataService _staticDataService;

        public HexEnchantSystem(GameContext game, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _enchants = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HexEnchant,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId
                ));
            
            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Armament
                ).NoneOf(GameMatcher.HexEnchant));
        }

        public void Execute()
        {
            foreach (GameEntity enchant in _enchants.GetEntities(_buffer2))
            foreach (GameEntity armament in _armaments.GetEntities(_buffer))
            {
                if(enchant.ProducerId != armament.ProducerId)
                    continue;
                
                EnchantConfig enchantConfig = _staticDataService.GetEnchantConfig(EnchantTypeId.Hex);

                GetOrAddStatusSetups(armament).AddRange(enchantConfig.StatusSetups);
                
                armament.isHexEnchant = true;
            }
        }
        
        private static List<StatusSetup> GetOrAddStatusSetups(GameEntity armament)
        {
            if (!armament.hasStatusSetups)
                armament.AddStatusSetups(new List<StatusSetup>(32));

            return armament.StatusSetups;
        }
    }

}