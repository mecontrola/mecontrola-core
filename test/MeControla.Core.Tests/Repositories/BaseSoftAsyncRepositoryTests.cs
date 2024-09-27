using FluentAssertions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Repositories;
using MeControla.Core.Tests.Mocks.Entities;
using MeControla.Core.Tests.Mocks.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.Core.Tests.Repositories;

public class BaseSoftAsyncRepositoryTests : BaseRepository
{
    private const long TOTAL_USERS = 3;

    private readonly ISoftUserRepository userRepository;

    public BaseSoftAsyncRepositoryTests()
        => userRepository = new SoftUserRepository(context);

    [Fact(DisplayName = "[BaseSoftAsyncRepository.RemoveAsync] Deve retornar a quantidade total, remover um usuario e retornar a quantidade menos o removido.")]
    public async Task DeveContarRemoverContaUsuario()
    {
        var total = await userRepository.CountAsync(GetCancellationToken());
        total.Should().Be(TOTAL_USERS);

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        total = await userRepository.CountAsync(GetCancellationToken());
        total.Should().Be(TOTAL_USERS - 1);
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.RemoveAsync] Deve retornar a quantidade especifica, remover um usuario e retornar a quantidade especifica menos o removido.")]
    public async Task DeveRemoverUsuario()
    {
        var total = await userRepository.CountAsync(entity => entity.Id == DataMock.INT_ID_3, GetCancellationToken());
        total.Should().Be(1);

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        total = await userRepository.CountAsync(entity => entity.Id == DataMock.INT_ID_3, GetCancellationToken());
        total.Should().Be(0);
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.FindAllPagedAsync] Deve listar todos os registros paginados, remover e listar todos registros paginados menos o removido.")]
    public async Task DeveRetornarListaRemoverRetornarLista()
    {
        var pagination = PaginationMock.CreatePage1();

        var list = await userRepository.FindAllPagedAsync(pagination, GetCancellationToken());
        list.Should().NotBeEmpty();
        list.Should().HaveCount((int)TOTAL_USERS);

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        list = await userRepository.FindAllPagedAsync(pagination, GetCancellationToken());
        list.Should().NotBeEmpty();
        list.Should().HaveCount((int)TOTAL_USERS - 1);
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.FindAllPagedAsync] Deve listar todos os registros especificos paginados, remover e listar todos registros especificos paginados menos o removido.")]
    public async Task DeveRetornarListaEspecificaRemoverRetornarListaEspecifica()
    {
        var pagination = PaginationMock.CreatePage1();

        var list = await userRepository.FindAllPagedAsync(pagination, entity => entity.Id == DataMock.INT_ID_3, GetCancellationToken());
        list.Should().NotBeEmpty();
        list.Should().HaveCount(1);

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        list = await userRepository.FindAllPagedAsync(pagination, entity => entity.Id == DataMock.INT_ID_3, GetCancellationToken());
        list.Should().BeEmpty();
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.FindAllPagedAsync] Deve listar todos os registros, remover e listar todos registros menos o removido.")]
    public async Task DeveRetornarListaTodaRemoverRetornarListaToda()
    {
        var list = await userRepository.FindAllAsync(GetCancellationToken());
        list.Should().NotBeEmpty();
        list.Should().HaveCount((int)TOTAL_USERS);

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        list = await userRepository.FindAllAsync(GetCancellationToken());
        list.Should().NotBeEmpty();
        list.Should().HaveCount((int)TOTAL_USERS - 1);
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.FindAllPagedAsync] Deve listar todos os registros especificos, remover e listar todos registros especificos menos o removido.")]
    public async Task DeveRetornarListaTodaEspecificaRemoverRetornarListaTodaEspecifica()
    {
        var pagination = PaginationMock.CreatePage1();

        var list = await userRepository.FindAllAsync(entity => entity.Id == DataMock.INT_ID_3, GetCancellationToken());
        list.Should().NotBeEmpty();
        list.Should().HaveCount(1);

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        list = await userRepository.FindAllAsync(entity => entity.Id == DataMock.INT_ID_3, GetCancellationToken());
        list.Should().BeEmpty();
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.FindAsync] Deve retornar objeto com o Id informado, remover e retornar null.")]
    public async Task DeveRetornarIdRemoverRetornarVazio()
    {
        var entity = await userRepository.FindAsync(DataMock.INT_ID_3, GetCancellationToken());
        entity.Should().NotBeNull();

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        entity = await userRepository.FindAsync(DataMock.INT_ID_3, GetCancellationToken());
        entity.Should().BeNull();
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.FindAsync] Deve retornar objeto com o Uuid informado, remover e retornar null.")]
    public async Task DeveRetornarUuidRemoverRetornarVazio()
    {
        var entity = await userRepository.FindAsync(DataMock.UUID_USER_3, GetCancellationToken());
        entity.Should().NotBeNull();

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        entity = await userRepository.FindAsync(DataMock.UUID_USER_3, GetCancellationToken());
        entity.Should().BeNull();
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.FindAsync] Deve existir objeto com o Id informado, remover e retornar false.")]
    public async Task DeveExistirIdRemoverNaoExistir()
    {
        var exist = await userRepository.ExistsAsync(DataMock.INT_ID_3, GetCancellationToken());
        exist.Should().BeTrue();

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        exist = await userRepository.ExistsAsync(DataMock.INT_ID_3, GetCancellationToken());
        exist.Should().BeFalse();
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.FindAsync] Deve existir objeto com o Uuid informado, remover e retornar false.")]
    public async Task DeveExistirUuidRemoverNaoExistir()
    {
        var exist = await userRepository.ExistsAsync(DataMock.UUID_USER_3, GetCancellationToken());
        exist.Should().BeTrue();

        await userRepository.RemoveAsync(SoftUserMock.CreateUser3(), GetCancellationToken());

        exist = await userRepository.ExistsAsync(DataMock.UUID_USER_3, GetCancellationToken());
        exist.Should().BeFalse();
    }

    [Fact(DisplayName = "[BaseSoftAsyncRepository.FindAsync] Deve retornar false quando tentar remover um existe que não existe e disparar a exceção DbUpdateConcurrencyException.")]
    public async Task DeveRetornarFalseQuandoGerarExcecao()
    {
        var actual = await userRepository.RemoveAsync(SoftUserMock.CreateUser4(), GetCancellationToken());

        actual.Should().BeFalse();
    }
}