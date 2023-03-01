using FluentAssertions;
using MeControla.Core.Tests.Mocks.Datas.Repositories;
using MeControla.Core.Tests.Mocks.Entities;
using MeControla.Core.Tests.Mocks.Repositories;
using Xunit;

namespace MeControla.Core.Tests.Repositories
{
    public class BaseManyAsyncRepositoryTests : BaseRepository
    {
        private readonly IUserPermissionRepository userPermissionRepository;

        public BaseManyAsyncRepositoryTests()
            => userPermissionRepository = new UserPermissionRepository(context);

        [Fact(DisplayName = "[BaseManyAsyncRepository.CreateAsync] Deve relacionar a permissão de usuário ao usuario 3 na tabela do banco de dados.")]
        public async void DeveRelacionarPermissaoAdministradorUsuario3()
        {
            var userPermission = UserPermissionMock.CreateUser3User();

            await userPermissionRepository.CreateAsync(userPermission, GetCancellationToken());

            var exist = await userPermissionRepository.ExistsAsync(userPermission, GetCancellationToken());

            exist.Should().BeTrue();
        }

        [Fact(DisplayName = "[BaseManyAsyncRepository.RemoveAsync] Deve desrelacionar a permissão de usuário ao usuario 2 na tabela do banco de dados.")]
        public async void DeveDesrelacionarPermissaoUsuarioUsuario2()
        {
            var userPermission = UserPermissionMock.CreateUser2User();

            await userPermissionRepository.RemoveAsync(userPermission, GetCancellationToken());

            var exist = await userPermissionRepository.ExistsAsync(userPermission, GetCancellationToken());

            exist.Should().BeFalse();
        }

        [Fact(DisplayName = "[BaseManyAsyncRepository.ExistsAsync] Deve chegar se o usuário 1 possui permissão de administrador relacionada.")]
        public async void DeveRetornarTrueQuandoExistirRelacao()
        {
            var userPermission = UserPermissionMock.CreateUser1Administrator();

            var exist = await userPermissionRepository.ExistsAsync(userPermission, GetCancellationToken());

            exist.Should().BeTrue();
        }
    }
}