namespace Scenes.BlockSpawner.Block
{
    public interface IBlockModel
    {
        int Hp { get; set; }
        int Cost { get; set; }
        void Reset(int tier);
        int DifficultMultiplier { get; set; }

    }
}
