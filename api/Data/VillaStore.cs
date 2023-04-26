using api.Models;
using api.Models.DTO;

namespace api.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> VillaList = new List<VillaDTO>
        {
            new VillaDTO{id=1, name="First Villa", sqft=100, occupancy=4 },
            new VillaDTO{id=2, name="Second Villa", sqft=300, occupancy=3 },
        };
    }
}
