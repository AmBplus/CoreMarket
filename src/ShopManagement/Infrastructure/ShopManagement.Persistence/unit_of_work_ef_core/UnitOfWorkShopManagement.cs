using Base.Infrastructure.UnitOfWork;
using ShopManagement.Application.Contract.Sm.UnitOfWork;

namespace ShopManagement.Persistence.unit_of_work_ef_core;

public class UnitOfWorkShopManagement :UnitOfWorkEfCore , IUnitOfWorkShopManagement
{
    public UnitOfWorkShopManagement(ShopManagementContext context) : base(context)
    {
    }
}