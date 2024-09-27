using FluentAssertions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Repositories;
using MeControla.Core.Tests.Mocks.Entities;
using MeControla.Core.Tests.Mocks.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.Core.Tests.Repositories;

public class BaseAsyncRepositoryTests : BaseRepository
{
    private const long TOTAL_USERS = 3;

    private readonly IUserRepository userRepository;

    public BaseAsyncRepositoryTests()
        => userRepository = new UserRepository(context);

    [Fact(DisplayName = "[BaseAsyncRepository.CountAsync] Deve retornar a quantidade total de registros na tabela do banco de dados.")]
    public async Task DeveListarTodosUsuarios()
    {
        var actual = await userRepository.CountAsync(GetCancellationToken());
        actual.Should().Be(TOTAL_USERS);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.CountAsync] Deve retornar a quantidade total de registros na tabela do banco de dados que coincidem com o criterio.")]
    public async Task DeveListarTodosUsuariosDaCondicao()
    {
        var actual = await userRepository.CountAsync(entity => entity.Id == DataMock.INT_ID_1, GetCancellationToken());
        actual.Should().Be(1);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.SaveAsync] Deve criar um usuario na tabela do banco de dados.")]
    public async Task DeveSalvarUsuarioNovo()
    {
        var expected = UserMock.CreateUser4();
        expected.Id = 0;

        expected = await userRepository.SaveAsync(expected, GetCancellationToken());

        var actual = await userRepository.FindAsync(entity => entity.Id == expected.Id, GetCancellationToken());
        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(expected, opt => opt.Excluding(field => field.Id));
    }

    [Fact(DisplayName = "[BaseAsyncRepository.SaveAsync] Deve atualizar um usuario na tabela do banco de dados.")]
    public async Task DeveSalvarUsuarioExistente()
    {
        var expected = UserMock.CreateUser3();
        expected.Name = DataMock.TEXT_USER_NAME_4;

        await userRepository.SaveAsync(expected, GetCancellationToken());

        var actual = await userRepository.FindAsync(entity => entity.Id == expected.Id, GetCancellationToken());
        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.SaveAsync] Deve retornar null quando algum erro ocorrer ao salvar.")]
    public async Task DeveRetornarNullQuandoOcorrerErro()
    {
        var user = UserMock.CreateUserEmpty();
        user.Name = null;

        var retorno = await userRepository.SaveAsync(user, GetCancellationToken());
        retorno.Should().BeNull();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.CreateAsync] Deve criar um usuario na tabela do banco de dados.")]
    public async Task DeveCriarUsuario()
    {
        var user = UserMock.CreateUser4();
        user.Id = 0;

        await userRepository.CreateAsync(user, GetCancellationToken());

        var total = await userRepository.CountAsync(entity => entity.Id == user.Id, GetCancellationToken());
        total.Should().Be(1);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.UpdateAsync] Deve atualizar um usuario na tabela do banco de dados.")]
    public async Task DeveAtualizarUsuario()
    {
        var expected = UserMock.CreateUser3();
        expected.Name = DataMock.TEXT_USER_NAME_4;

        await userRepository.UpdateAsync(expected, GetCancellationToken());

        var actual = await userRepository.FindAsync(entity => entity.Id == expected.Id, GetCancellationToken());
        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.RemoveAsync] Deve remover um usuario na tabela do banco de dados.")]
    public async Task DeveRemoverUsuario()
    {
        var user = UserMock.CreateUser3();

        await userRepository.RemoveAsync(user, GetCancellationToken());

        var total = await userRepository.CountAsync(entity => entity.Id == user.Id, GetCancellationToken());
        total.Should().Be(0);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAllPagedAsync] Deve retornar lista paginada dos registros que existir na tabela do banco de dados.")]
    public async Task DeveRetornarListaPaginadaComRegistros()
    {
        var pagination = PaginationMock.CreatePage1();

        var actual = await userRepository.FindAllPagedAsync(pagination, GetCancellationToken());

        actual.Should().NotBeEmpty();
        actual.Should().HaveCount((int)TOTAL_USERS);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAllPagedAsync] Deve retornar lista paginada de todos os registros que exitir na tabela do banco de dados que coincidem com o criterio informado.")]
    public async Task DeveRetornarListaPaginadaComRegistrosQuandoCriterioAtendido()
    {
        var pagination = PaginationMock.CreatePage1();

        var actual = await userRepository.FindAllPagedAsync(pagination, entity => entity.Id < DataMock.INT_ID_4, GetCancellationToken());

        actual.Should().NotBeEmpty();
        actual.Should().HaveCount((int)TOTAL_USERS);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAllPagedAsync] Deve retornar lista paginada vazia quando existir registro que não coincidem com o criterio informado.")]
    public async Task DeveRetornarListaPaginadaSemRegistrosQuandoCriterioNaoAtendido()
    {
        var pagination = PaginationMock.CreatePage1();

        var actual = await userRepository.FindAllPagedAsync(pagination, entity => entity.Id >= DataMock.INT_ID_4, GetCancellationToken());

        actual.Should().BeEmpty();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAllAsync] Deve retornar lista de todos os registro que existir na tabela do banco de dados.")]
    public async Task DeveRetornarListaRegistros()
    {
        var actual = await userRepository.FindAllAsync(GetCancellationToken());

        actual.Should().NotBeEmpty();
        actual.Should().HaveCount((int)TOTAL_USERS);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAllAsync] Deve retornar lista de todos os registro que exitir na tabela do banco de dados que coincidem com o criterio informado.")]
    public async Task DeveRetornarListaRegistrosQuandoCriterioAtendido()
    {
        var actual = await userRepository.FindAllAsync(entity => entity.Id < DataMock.INT_ID_4, GetCancellationToken());

        actual.Should().NotBeEmpty();
        actual.Should().HaveCount((int)TOTAL_USERS);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAllAsync] Deve retornar lista vazia quando existir registro que não coincidem com o criterio informado.")]
    public async Task DeveRetornarListaVaziaQuandoCriterioNaoAtendido()
    {
        var actual = await userRepository.FindAllAsync(entity => entity.Id >= DataMock.INT_ID_4, GetCancellationToken());

        actual.Should().BeEmpty();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAsync] Deve retornar objeto se exitir na tabela do banco de dados algum registro que conincida com o Id.")]
    public async Task DeveRetornarObjetoQuandoIdInformado()
    {
        var expected = UserMock.CreateUser3();
        var actual = await userRepository.FindAsync(expected.Id, GetCancellationToken());

        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAsync] Deve retornar null não se exitir na tabela do banco de dados algum registro que conincida com o Id.")]
    public async Task DeveRetornarNullQuandoIdInformado()
    {
        var exist = await userRepository.FindAsync(DataMock.INT_ID_4, GetCancellationToken());

        exist.Should().BeNull();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAsync] Deve retornar objeto se exitir na tabela do banco de dados algum registro que conincida com o Guid.")]
    public async Task DeveRetornarObjetoQuandoGuidInformado()
    {
        var expected = UserMock.CreateUser3();
        var actual = await userRepository.FindAsync(expected.Uuid, GetCancellationToken());

        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAsync] Deve retornar null não se exitir na tabela do banco de dados algum registro que conincida com o Guid.")]
    public async Task DeveRetornarNullQuandoGuidInformado()
    {
        var exist = await userRepository.FindAsync(DataMock.UUID_USER_4, GetCancellationToken());

        exist.Should().BeNull();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAsync] Deve retornar objeto se exitir na tabela do banco de dados algum registro que conincida com o criterio.")]
    public async Task DeveRetornarObjetoQuandoCriteriaComCoincidencia()
    {
        var expected = UserMock.CreateUser3();
        var actual = await userRepository.FindAsync(entity => entity.Uuid == expected.Uuid, GetCancellationToken());

        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(DisplayName = "[BaseAsyncRepository.FindAsync] Deve retornar null não se exitir na tabela do banco de dados algum registro que conincida com o criterio.")]
    public async Task DeveRetornarNullQuandoCriteriaSemCoincidencia()
    {
        var exist = await userRepository.FindAsync(entity => entity.Uuid == DataMock.UUID_USER_4, GetCancellationToken());

        exist.Should().BeNull();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.ExistsAsync] Deve retornar true se exitir na tabela do banco de dados algum registro que conincida com o Id.")]
    public async Task DeveRetornarTrueQuandoIdInformado()
    {
        var exist = await userRepository.ExistsAsync(DataMock.INT_ID_3, GetCancellationToken());

        exist.Should().BeTrue();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.ExistsAsync] Deve retornar false não se exitir na tabela do banco de dados algum registro que conincida com o Id.")]
    public async Task DeveRetornarFalseQuandoIdInformado()
    {
        var exist = await userRepository.ExistsAsync(DataMock.INT_ID_4, GetCancellationToken());

        exist.Should().BeFalse();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.ExistsAsync] Deve retornar true se exitir na tabela do banco de dados algum registro que conincida com o Guid.")]
    public async Task DeveRetornarTrueQuandoGuidInformado()
    {
        var exist = await userRepository.ExistsAsync(DataMock.UUID_USER_3, GetCancellationToken());

        exist.Should().BeTrue();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.ExistsAsync] Deve retornar false não se exitir na tabela do banco de dados algum registro que conincida com o Guid.")]
    public async Task DeveRetornarFalseQuandoGuidInformado()
    {
        var exist = await userRepository.ExistsAsync(DataMock.UUID_USER_4, GetCancellationToken());

        exist.Should().BeFalse();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.ExistsAsync] Deve retornar true se exitir na tabela do banco de dados algum registro que conincida com o criterio.")]
    public async Task DeveRetornarTrueQuandoCriteriaInformado()
    {
        var exist = await userRepository.ExistsAsync(entity => entity.Uuid == DataMock.UUID_USER_3, GetCancellationToken());

        exist.Should().BeTrue();
    }

    [Fact(DisplayName = "[BaseAsyncRepository.ExistsAsync] Deve retornar false não se exitir na tabela do banco de dados algum registro que conincida com o criterio.")]
    public async Task DeveRetornarFalseQuandoCriteriaInformado()
    {
        var exist = await userRepository.ExistsAsync(entity => entity.Uuid == DataMock.UUID_USER_4, GetCancellationToken());

        exist.Should().BeFalse();
    }
}