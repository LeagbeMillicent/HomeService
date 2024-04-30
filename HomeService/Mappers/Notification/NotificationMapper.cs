using AutoMapper;
using HomeService.Application.DTOs.NotificationDto;
using HomeService.Domain;

namespace HomeService.API.Mappers.Notification
{
    public class NotificationMapper : Profile
    {
        public NotificationMapper() 
        {
            CreateMap<tblNotification, AddNotificationDto>().ReverseMap();
            CreateMap<tblNotification, UpdateNotificationDto>().ReverseMap();
            CreateMap<tblNotification, DeleteNotificationDto>().ReverseMap();

        }

    }
}
