using AutoMapper;
using AnnouncementWebApi.Data;
using AnnouncementWebApi.Entities;
using AnnouncementWebApi.Exceptions;
using AnnouncementWebApi.Helpers;
using AnnouncementWebApi.Interfaces;
using AnnouncementWebApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementWebApi.Services;

public sealed class AnnouncementService : BaseService, IAnnouncementService
{
    public AnnouncementService(AnnouncementInventoryDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    public async Task<AnnouncementDto> AddAnnouncementAsync(AnnouncementDto announcementDto)
    {
        var announcementEntity = _mapper.Map<Announcement>(announcementDto);
        announcementEntity.DateAdded = DateTime.UtcNow;
        var createdAnnouncement = (await _context.Announcements.AddAsync(announcementEntity)).Entity;
        await _context.SaveChangesAsync();

        return _mapper.Map<AnnouncementDto>(createdAnnouncement);
    }

    public async Task<AnnouncementDto> UpdateAnnouncementAsync(int announcementId, AnnouncementDto announcementDto)
    {
        var existingAnnouncement = await _context.Announcements.FindAsync(announcementId);
        if (existingAnnouncement is null)
        {
            throw new EntityNotFoundException();
        }

        var originalDateAdded = existingAnnouncement.DateAdded;
        _mapper.Map(announcementDto, existingAnnouncement);
        existingAnnouncement.Id = announcementId;
        existingAnnouncement.DateAdded = originalDateAdded;
        await _context.SaveChangesAsync();

        return _mapper.Map<AnnouncementDto>(existingAnnouncement)!;
    }

    public async Task DeleteAnnouncementAsync(int announcementId)
    {
        var announcement = await _context.Announcements.FindAsync(announcementId);
        if (announcement is null)
        {
            throw new EntityNotFoundException();
        }

        _context.Announcements.Remove(announcement);
        await _context.SaveChangesAsync();
    }

    public async Task<AnnouncementDetailsDto> GetAnnouncementDetailsAsync(int announcementId)
    {
        var announcement = await _context.Announcements.FindAsync(announcementId);
        if (announcement is null)
        {
            throw new EntityNotFoundException();
        }

        var similarAnnouncements = GetMostSimilarAnnouncements(announcement);
        var announcementDetailsDto = _mapper.Map<AnnouncementDetailsDto>(announcement);
        announcementDetailsDto.SimilarAnnouncements = _mapper.Map<List<AnnouncementDto>>(similarAnnouncements);

        return announcementDetailsDto;
    }

    public async Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync()
    {
        var announcements = await _context.Announcements.ToListAsync();

        return _mapper.Map<List<AnnouncementDto>>(announcements)!;
    }


    private List<Announcement> GetMostSimilarAnnouncements(Announcement announcement)
    {
        return _context.Announcements
                .Where(a => a.Id != announcement.Id)
                .AsEnumerable()
                .Select(a =>
                {
                    var (titleMatchCount, descriptionMatchCount) = AnnouncementComparer.GetMatchingWordCount(announcement, a);
                    return new
                    {
                        Announcement = a,
                        TitleMatchCount = titleMatchCount,
                        DescriptionMatchCount = descriptionMatchCount,
                        TotalMatchCount = titleMatchCount + descriptionMatchCount
                    };
                })
                .Where(x => x.TitleMatchCount > 0 && x.DescriptionMatchCount > 0)
                .OrderByDescending(x => x.TotalMatchCount)
                .Take(3)
                .Select(x => x.Announcement)
                .ToList();
    }
}
