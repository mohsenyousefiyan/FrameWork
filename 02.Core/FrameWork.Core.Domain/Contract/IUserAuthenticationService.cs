using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.Core.Domain.Dtos.AuthenticationDto;

namespace FrameWork.Core.Domain.Contract
{
    public interface IUserAuthenticationService
    {
        CommandResult<UserValidationResulDto> Handle(string accessToken);
    }
}
