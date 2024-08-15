using AutoMapper;
using AnnouncementWebApi.Data;

namespace AnnouncementWebApi.Services.Abstract;

public abstract class BaseService
{
    private protected readonly AnnouncementInventoryDbContext _context;
    private protected readonly IMapper _mapper;

    public BaseService(AnnouncementInventoryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}