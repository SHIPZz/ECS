using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemies.Registrar
{
    public class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        public EnemyAnimator EnemyAnimator;

        public override void RegisterComponents()
        {
            Entity.AddEnemyAnimator(EnemyAnimator);
            Entity.AddDamageTakenAnimator(EnemyAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEnemyAnimator)
                Entity.RemoveEnemyAnimator();
            
            if (Entity.hasDamageTakenAnimator)
                Entity.RemoveDamageTakenAnimator();
        }
    }
}