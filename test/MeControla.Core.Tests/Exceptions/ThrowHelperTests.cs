using MeControla.Core.Exceptions;
using MeControla.Core.Tests.Exceptions.Bases;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using MeControla.Core.Tests.Mocks.FluentValidation;
using MeControla.Core.Tests.Mocks.Primitives;
using System.Net;
using Xunit;

namespace MeControla.Core.Tests.Exceptions;

public class ThrowHelperTests : BaseExceptionHelperTests
{
    [Theory(DisplayName = "[ThrowHelper.ThrowBadGatewayException] Deve gerar exceção do tipo BadGatewayException.")]
    [MemberData(nameof(GetBadGatewayException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarBadGatewayException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<BadGatewayException>("ThrowBadGatewayException", args);

    public static TheoryData<ThrowHelperArgument> GetBadGatewayException()
        => CreateParamExceptionTests(HttpStatusCode.BadGateway, ResourceThrowMessageDefault.BadGateway, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowBadRequestException] Deve gerar exceção do tipo BadRequestException.")]
    [MemberData(nameof(GetBadRequestException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarBadRequestException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<BadRequestException>("ThrowBadRequestException", args);

    public static TheoryData<ThrowHelperArgument> GetBadRequestException()
        => CreateParamExceptionTests(HttpStatusCode.BadRequest, ResourceThrowMessageDefault.BadRequest, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowForbiddenException] Deve gerar exceção do tipo ForbiddenException.")]
    [MemberData(nameof(GetForbiddenException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarForbiddenException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<ForbiddenException>("ThrowForbiddenException", args);

    public static TheoryData<ThrowHelperArgument> GetForbiddenException()
        => CreateParamExceptionTests(HttpStatusCode.Forbidden, ResourceThrowMessageDefault.Forbidden, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowGoneException] Deve gerar exceção do tipo GoneException.")]
    [MemberData(nameof(GetGoneException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarGoneException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<GoneException>("ThrowGoneException", args);

    public static TheoryData<ThrowHelperArgument> GetGoneException()
        => CreateParamExceptionTests(HttpStatusCode.Gone, ResourceThrowMessageDefault.Gone, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowInternalServerErrorException] Deve gerar exceção do tipo InternalServerErrorException.")]
    [MemberData(nameof(GetInternalServerErrorException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarInternalServerErrorException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<InternalServerErrorException>("ThrowInternalServerErrorException", args);

    public static TheoryData<ThrowHelperArgument> GetInternalServerErrorException()
        => CreateParamExceptionTests(HttpStatusCode.InternalServerError, ResourceThrowMessageDefault.InternalServerError, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowJWTTokenException] Deve gerar exceção do tipo JWTTokenException.")]
    [MemberData(nameof(GetJWTTokenException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarJWTTokenException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<JWTTokenException>("ThrowJWTTokenException", args);

    public static TheoryData<ThrowHelperArgument> GetJWTTokenException()
        => CreateParamExceptionTests(HttpStatusCode.Unauthorized, ResourceThrowMessageDefault.Unauthorized, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowNotFoundException] Deve gerar exceção do tipo NotFoundException.")]
    [MemberData(nameof(GetNotFoundException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarNotFoundException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<NotFoundException>("ThrowNotFoundException", args);

    public static TheoryData<ThrowHelperArgument> GetNotFoundException()
        => CreateParamExceptionTests(HttpStatusCode.NotFound, ResourceThrowMessageDefault.NotFound, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowNotImplementedException] Deve gerar exceção do tipo NotImplementedException.")]
    [MemberData(nameof(GetNotImplementedException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarNotImplementedException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<NotImplementedException>("ThrowNotImplementedException", args);

    public static TheoryData<ThrowHelperArgument> GetNotImplementedException()
        => CreateParamExceptionTests(HttpStatusCode.NotImplemented, ResourceThrowMessageDefault.NotImplemented, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowPaymentRequiredException] Deve gerar exceção do tipo PaymentRequiredException.")]
    [MemberData(nameof(GetPaymentRequiredException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarPaymentRequiredException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<PaymentRequiredException>("ThrowPaymentRequiredException", args);

    public static TheoryData<ThrowHelperArgument> GetPaymentRequiredException()
        => CreateParamExceptionTests(HttpStatusCode.PaymentRequired, ResourceThrowMessageDefault.PaymentRequired, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowServiceUnavailableException] Deve gerar exceção do tipo ServiceUnavailableException.")]
    [MemberData(nameof(GetServiceUnavailableException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarServiceUnavailableException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<ServiceUnavailableException>("ThrowServiceUnavailableException", args);

    public static TheoryData<ThrowHelperArgument> GetServiceUnavailableException()
        => CreateParamExceptionTests(HttpStatusCode.ServiceUnavailable, ResourceThrowMessageDefault.ServiceUnavailable, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Theory(DisplayName = "[ThrowHelper.ThrowUnauthorizedException] Deve gerar exceção do tipo UnauthorizedException.")]
    [MemberData(nameof(GetUnauthorizedException), MemberType = typeof(ThrowHelperTests))]
    public void DeveValidarUnauthorizedException(ThrowHelperArgument args)
        => ExecuteAndValidateTests<UnauthorizedException>("ThrowUnauthorizedException", args);

    public static TheoryData<ThrowHelperArgument> GetUnauthorizedException()
        => CreateParamExceptionTests(HttpStatusCode.Unauthorized, ResourceThrowMessageDefault.Unauthorized, DataMock.TEXT_EXCEPTION_MESSAGE, ExceptionMock.Create());

    [Fact(DisplayName = "[ThrowHelper.ThrowValidationException] Deve gerar exceção do tipo ValidationException somente com os campos com erro.")]
    public void DeveValidarValidationException()
    {
        var instance = Assert.Throws<ValidationException<User>>(() =>
        {
            ThrowHelper.ThrowValidationException<User>(ValidationResultMock.CreateFillUser());
        });

        ShouldBe(instance, HttpStatusCode.BadRequest, DataMock.TEXT_FORM_EXCEPTION_MESSAGE, null);
    }

    [Fact(DisplayName = "[ThrowHelper.ThrowValidationException] Deve gerar exceção do tipo ValidationException informando os campos com erro e uma mensagem.")]
    public void DeveValidarValidationException2()
    {
        var instance = Assert.Throws<ValidationException<User>>(() =>
        {
            ThrowHelper.ThrowValidationException<User>(ValidationResultMock.CreateFillUser(), DataMock.TEXT_EXCEPTION_MESSAGE);
        });

        ShouldBe(instance, HttpStatusCode.BadRequest, DataMock.TEXT_EXCEPTION_MESSAGE, null);
    }

    [Fact(DisplayName = "[ThrowHelper.ThrowValidationException] Deve gerar exceção do tipo ValidationException informando os campos com erro, uma mensagem e innerException.")]
    public void DeveValidarValidationException3()
    {
        var innerException = ExceptionMock.Create();

        var instance = Assert.Throws<ValidationException<User>>(() =>
        {
            ThrowHelper.ThrowValidationException<User>(ValidationResultMock.CreateFillUser(), DataMock.TEXT_EXCEPTION_MESSAGE, innerException);
        });

        ShouldBe(instance, HttpStatusCode.BadRequest, DataMock.TEXT_EXCEPTION_MESSAGE, innerException);
    }
}