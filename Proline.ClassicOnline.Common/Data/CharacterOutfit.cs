namespace Proline.ClassicOnline.Common.Data
{
    public class CharacterOutfit
    {
        public string OutfitName { get; set; } = "";
        public OutfitComponent[] Components { get; set; } = new OutfitComponent[12];
    }
}
