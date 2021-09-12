using System.Collections.Generic;

namespace GuidanceWebAPI.DAService
{
    public interface ICRUDDAService<DA>
    {
        DA AddItem(DA item);
        List<DA> AddItems(List<DA> items);
        List<DA> GetItems();
        DA GetItem(int Id);
        DA UpdateItem(DA item);
        int RemoveItem(int Id);
    }
}
