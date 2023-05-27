using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ShoppingCartAPI.DataAccess.Interfaces
{
    public interface IShoppingCartDataSet
    {
        DbSet<ProductMasterEntity> productMasterEntity { get; }
    }
}
