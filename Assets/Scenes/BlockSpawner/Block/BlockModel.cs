namespace Scenes.BlockSpawner.Block
{
    public class BlockModel : IBlockModel
    {
        public int Hp { get; set; }
        public int Cost { get; set; }
        
        public BlockModel(int hp)
        {
            Hp = hp;
            Cost = hp * 2;
        }
        
    }
}
