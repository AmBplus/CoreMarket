﻿using Base.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Base.Infrastructure.UnitOfWork;

public class UnitOfWorkEfCore : IUnitOfWorkEf
{
    private readonly DbContext _context;

    public UnitOfWorkEfCore(DbContext context)
    {
        _context = context;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
