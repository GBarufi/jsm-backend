using JSM.Application.Queries.Users;
using JSM.Domain.Enums;
using JSM.Domain.Extensions;
using JSM.Domain.Models;
using JSM.Persistence.Contexts;
using JSM.UnitTests.Helpers;
using JSM.UnitTests.Helpers.Fakers;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace JSM.UnitTests.Tests.Application.Queries.Users
{
    public class GetUsersQueryHandlerTest
    {
        private readonly GetUsersQueryHandler _handler;
        private readonly string _userNameToFilter = "João";
        private readonly string _userNameDifferentFromFilter = "José";
        private readonly string _regionToFilter = "South";
        private readonly string _regionDifferentFromFilter = "North";
        private readonly string _stateToFilter = "SC";
        private readonly string _stateDifferentFromFilter = "SP";
        private readonly string _cityToFilter = "Criciúma";
        private readonly string _cityDifferentFromFilter = "São Paulo";

        public GetUsersQueryHandlerTest()
        {
            var _dbContextFactoryMock = new Mock<IDbContextFactory<JsmContext>>();

            _dbContextFactoryMock
                .Setup(x => x.CreateDbContextAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => JsmContextFactory.CreateInMemory((dbContext) =>
                {
                    if (!dbContext.Users.Any())
                    {
                        var userWithPredefinedName = GenerateUserWithPredefinedProperties(
                            name: _userNameToFilter,
                            region: _regionDifferentFromFilter,
                            state: _stateDifferentFromFilter,
                            city: _cityDifferentFromFilter);

                        var userWithPredefinedRegion = GenerateUserWithPredefinedProperties(
                            name: _userNameDifferentFromFilter,
                            region: _regionToFilter,
                            state: _stateDifferentFromFilter,
                            city: _cityDifferentFromFilter);

                        var userWithPredefinedState = GenerateUserWithPredefinedProperties(
                            name: _userNameDifferentFromFilter,
                            region: _regionDifferentFromFilter,
                            state: _stateToFilter,
                            city: _cityDifferentFromFilter);

                        var userWithPredefinedCity = GenerateUserWithPredefinedProperties(
                            name: _userNameDifferentFromFilter,
                            region: _regionDifferentFromFilter,
                            state: _stateDifferentFromFilter,
                            city: _cityToFilter);

                        dbContext.Users.AddRange([
                            userWithPredefinedName,
                            userWithPredefinedRegion,
                            userWithPredefinedState,
                            userWithPredefinedCity
                        ]);

                        dbContext.SaveChanges();
                    }
                }));

            _handler = new GetUsersQueryHandler(_dbContextFactoryMock.Object);
        }

        [Fact]
        public async Task Handle_WhenHasMoreRecordsThanPageSize_ShouldReturnUsersPaginatedResponse()
        {
            // Arrange
            var firstPageQuery = new GetUsersQuery { Page = 0, Size = 2 };
            var secondPageQuery = new GetUsersQuery { Page = 1, Size = 2 };

            // Act
            var firstPageResponse = await _handler.Handle(firstPageQuery, new CancellationToken());
            var secondPageResponse = await _handler.Handle(secondPageQuery, new CancellationToken());

            // Assert
            Assert.NotNull(firstPageResponse);
            Assert.NotNull(secondPageResponse);
            Assert.Equal(2, firstPageResponse.Users?.Count);
            Assert.Equal(2, secondPageResponse.Users?.Count);
        }

        [Fact]
        public async Task Handle_WhenReceivesUserNameOnRequest_ShouldReturnFilteredResponse()
        {
            // Arrange
            var query = new GetUsersQuery
            {
                Name = _userNameToFilter
            };

            // Act
            var response = await _handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(response);
            Assert.Single(response.Users!);
            Assert.Equal(_userNameToFilter, response.Users!.First().Name.First);
        }

        [Fact]
        public async Task Handle_WhenReceivesUserStateOnRequest_ShouldReturnFilteredResponse()
        {
            // Arrange
            var query = new GetUsersQuery
            {
                State = _stateToFilter
            };

            // Act
            var response = await _handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(response);
            Assert.Single(response.Users!);
            Assert.Equal(Enum.Parse<LocationState>(_stateToFilter).GetDisplayName(), response.Users!.First().Location.State);
        }

        [Fact]
        public async Task Handle_WhenReceivesUserTypeOnRequest_ShouldReturnFilteredResponse()
        {
            // Arrange
            var typeToFilter = "Laborious";
            var query = new GetUsersQuery
            {
                Type = typeToFilter
            };

            // Act
            var response = await _handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(response);
            Assert.Equal(0, response.Users!.Count(x => !x.Type.Equals(typeToFilter, StringComparison.CurrentCultureIgnoreCase)));
        }

        private static User GenerateUserWithPredefinedProperties(
            string? name = null,
            string? region = null,
            string? state = null,
            string? city = null)
        {
            var model = UserFaker.Generate();

            var hasPredefinedProperties = name is not null
                                       || region is not null
                                       || state is not null
                                       || city is not null;

            if (!hasPredefinedProperties)
                return model;

            return new User(
                model.Gender,
                model.Title,
                name is not null ? name : model.FirstName,
                model.LastName,
                model.Email,
                model.Birthday,
                model.Registered,
                model.TelephoneNumbers.First(),
                model.MobileNumbers.First(),
                model.Nationality,
                new UserLocation(
                    model.Location!.Street,
                    city is not null ? city : model.Location!.City,
                    state is not null ? Enum.Parse<LocationState>(state).GetDisplayName() : model.Location!.State,
                    model.Location!.PostCode,
                    model.Location!.Latitude,
                    model.Location!.Longitude,
                    model.Location!.TimezoneOffset,
                    model.Location!.TimezoneDescription
                ),
                model.Portrait!
            );
        }
    }
}
