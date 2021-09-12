using System.Collections.Generic;
using GuidanceDataAccess.DAModel;

namespace GuidanceWebAPI.DAService.Entity_Framework
{

    public class EFCRUDDAService<DA> : ICRUDDAService<DA>
    {
        private ICRUDContext<DA> _context;

        public EFCRUDDAService(ICRUDContext<DA> context)
        {
            _context = context;
        }

        public DA AddItem(DA item)
        {
            return _context.AddToContext(item);
        }

        public List<DA> AddItems(List<DA> items)
        {
            return _context.AddToContext(items);
        }

        public List<DA> GetItems()
        {
            return _context.GetAllFromContext();
        }

        public DA GetItem(int Id)
        {
            var item = _context.GetFromContext(Id);
            return item;
            //return _context.GetFromContext(Id);
        }

        public DA UpdateItem(DA item)
        {
            return _context.UpdateContext(item);
        }

        public int RemoveItem(int Id)
        {
            return _context.RemoveFromContext(Id);
        }
    }
}