using Code.Gameplay.Common.Visuals;

namespace Code.Infrastructure.View.Registrars
{
    public class StatusVisualsRegistrar : EntityComponentRegistrar
    {
        public StatusVisuals StatusVisuals;

        public override void RegisterComponents()
        {
            Entity.AddStatusVisuals(StatusVisuals);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasStatusVisuals)
                Entity.RemoveStatusVisuals();
        }
    }
}