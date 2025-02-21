namespace Code.Meta.Factory
{
    public interface IMetaFactory
    {
        MetaEntity CreateGold();
        MetaEntity CreateRollTimer();
        MetaEntity CreateEnergy();
    }
}