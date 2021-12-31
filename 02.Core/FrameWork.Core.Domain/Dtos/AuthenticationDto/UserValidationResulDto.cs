using System;

namespace FrameWork.Core.Domain.Dtos.AuthenticationDto
{
    public class UserValidationResulDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeviceUniqueId { get; set; }
    }
}
