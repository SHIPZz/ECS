using System.Collections.Generic;
using Code.States.GameStates;
using Code.States.StateMachine;
using Entitas;

namespace Code.Gameplay.Features.GameOver
{
    public class GameOverOnHeroDeathSystem : ReactiveSystem<GameEntity>
    {
        private IGameStateMachine _gameStateMachine;
        
        public GameOverOnHeroDeathSystem(IContext<GameEntity> game, IGameStateMachine gameStateMachine) : base(game)
        {
            _gameStateMachine = gameStateMachine;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.Dead)
                .Added())
                ;

        protected override bool Filter(GameEntity hero) => hero.isDead;

        protected override void Execute(List<GameEntity> heroes)
        {
            foreach (GameEntity entity in heroes)
            {
             _gameStateMachine.Enter<GameOverState>();   
            }
        }
    }

}