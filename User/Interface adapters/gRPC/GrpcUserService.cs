using Grpc.Core;
using UserMicroservice.Application.UseCases;
using UserMicroservice.GrpcServices;

namespace UserMicroservice.Interface_adapters.gRPC
{
    public class GrpcUserService : UsergRPCService.UsergRPCServiceBase
    {
        private readonly GetUserByEmailUseCase _getUserByEmailUseCase;
        private readonly CreateUserUseCase _createUserUseCase;
        private readonly GetUserByIdUseCase _getUserByIdUseCase;
        private readonly UpdateUserUseCase _updateUserUseCase;
        private readonly DeleteUserUseCase _deleteUserUseCase;

        public GrpcUserService(
            GetUserByEmailUseCase getUserByEmailUseCase,
            CreateUserUseCase createUserUseCase,
            GetUserByIdUseCase getUserByIdUseCase,
            UpdateUserUseCase updateUserUseCase,
            DeleteUserUseCase deleteUserUseCase)
        {
            _getUserByEmailUseCase = getUserByEmailUseCase ?? throw new ArgumentNullException(nameof(getUserByEmailUseCase));
            _createUserUseCase = createUserUseCase ?? throw new ArgumentNullException(nameof(createUserUseCase));
            _getUserByIdUseCase = getUserByIdUseCase ?? throw new ArgumentNullException(nameof(getUserByIdUseCase));
            _updateUserUseCase = updateUserUseCase ?? throw new ArgumentNullException(nameof(updateUserUseCase));
            _deleteUserUseCase = deleteUserUseCase ?? throw new ArgumentNullException(nameof(deleteUserUseCase));
        }

        // Opret en bruger
        public override async Task<UserReply> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));
            }

            try
            {
                var user = await _createUserUseCase.Execute(
                    request.Username, request.Password, request.Firstname, request.Lastname, request.Email);

                return new UserReply
                {
                    Id = user.UserID,
                    Username = user.Username,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email
                };
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to create user: {ex.Message}"));
            }
        }

        // Hent en bruger baseret på ID
        public override async Task<UserReply> GetUserById(UserByIdRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));
            }

            try
            {
                var user = await _getUserByIdUseCase.Execute(request.Id);

                if (user == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
                }

                return new UserReply
                {
                    Id = user.UserID,
                    Username = user.Username,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email
                };
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to get user: {ex.Message}"));
            }
        }

        // Hent en bruger baseret på email
        public override async Task<UserReply> GetUserByEmail(UserByEmailRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));
            }

            try
            {
                var user = await _getUserByEmailUseCase.Execute(request.Email);

                if (user == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
                }

                return new UserReply
                {
                    Id = user.UserID,
                    Username = user.Username,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email
                };
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to get user: {ex.Message}"));
            }
        }

        // Opdater en bruger
        public override async Task<UserReply> UpdateUser(UpdateUserRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));
            }

            try
            {
                var user = await _getUserByIdUseCase.Execute(request.Id);

                if (user == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
                }

                // Opdater brugerens data
                user.Username = request.Username;
                user.Password = request.Password;
                user.Firstname = request.Firstname;
                user.Lastname = request.Lastname;
                user.Email = request.Email;

                await _updateUserUseCase.Execute(
                    user.UserID, user.Username, user.Password,
                    user.Firstname, user.Lastname, user.Email);

                return new UserReply
                {
                    Id = user.UserID,
                    Username = user.Username,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email
                };
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to update user: {ex.Message}"));
            }
        }

        // Slet en bruger
        public override async Task<DeleteReply> DeleteUser(DeleteUserRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));
            }

            try
            {
                var user = await _getUserByIdUseCase.Execute(request.Id);

                if (user == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
                }

                await _deleteUserUseCase.Execute(user.UserID);

                return new DeleteReply
                {
                    Message = "User deleted successfully."
                };
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to delete user: {ex.Message}"));
            }
        }
    }
}
