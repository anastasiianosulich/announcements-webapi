using AnnouncementWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnnouncementController : ControllerBase
{
    private readonly IAnnouncementService _announcementService;

    public AnnouncementController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    [HttpPost]
    public async Task<ActionResult<AnnouncementDto>> AddAnnouncement([FromBody] AnnouncementDto announcementDto)
    {
        return Ok(await _announcementService.AddAnnouncementAsync(announcementDto));
    }

    [HttpPut("{announcementId}")]
    public async Task<ActionResult<AnnouncementDto>> UpdateAnnouncement(int announcementId, AnnouncementDto announcementDto)
    {
        return Ok(await _announcementService.UpdateAnnouncementAsync(announcementId, announcementDto));
    }

    [HttpDelete("{announcementId}")]
    public async Task<IActionResult> DeleteProject(int announcementId)
    {
        await _announcementService.DeleteAnnouncementAsync(announcementId);
        return NoContent();
    }

    [HttpGet("{announcementId}")]
    public async Task<ActionResult<AnnouncementDto>> GetProject(int announcementId)
    {
        return Ok(await _announcementService.GetAnnouncementDetailsAsync(announcementId));
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<AnnouncementDto>>> GetAllAnnouncements()
    {
        return Ok(await _announcementService.GetAllAnnouncementsAsync());
    }
}
