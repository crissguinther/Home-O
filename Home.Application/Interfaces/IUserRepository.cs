using Homeo.DTOs.Response;

namespace Homeo.Application.Interfaces {
    public interface IUserRepository {
        Task<UserResponseDTO> AddUser();
    }
}
