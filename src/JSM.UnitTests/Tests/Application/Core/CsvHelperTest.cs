﻿using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using JSM.Application.Dtos.Users;
using JSM.Application.Mappers.Users;
using JSM.UnitTests.Helpers;
using JSM.UnitTests.Helpers.Mappers;
using System.Globalization;
using CSVHelper = JSM.Application.Core.CsvHelper;

namespace JSM.UnitTests.Tests.Application.Core
{
    public class CsvHelperTest
    {
        private readonly CSVHelper _csvHelper = new();
        private readonly string[] _expectedFields = [
            "gender",
            "name__title",
            "name__first",
            "name__last",
            "location__street",
            "location__city",
            "location__state",
            "location__postcode",
            "location__coordinates__latitude",
            "location__coordinates__longitude",
            "location__timezone__offset",
            "location__timezone__description",
            "email",
            "dob__date",
            "dob__age",
            "registered__date",
            "registered__age",
            "phone",
            "cell",
            "picture__large",
            "picture__medium",
            "picture__thumbnail"
        ];

        [Fact]
        public void ImportCsv_WhenUserDataWasInformedCorrectly_ShouldReturnDataList()
        {
            // Arrange
            var byteArray = GenerateUserInputDtoAsByteArray();

            // Arrange
            var result = _csvHelper.ImportCsv<UserInputDto, UserCsvMapper>(byteArray);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void ImportCsv_WhenUserDataWasNotInformedCorrectly_ShouldThrowsException()
        {
            // Arrange
            var byteArray = GenerateUserInputDtoAsByteArray(missingProperty: true);

            // Arrange
            void importCsv() => _csvHelper.ImportCsv<UserInputDto, UserCsvMapper>(byteArray);

            // Assert
            Assert.Throws<HeaderValidationException>(importCsv);
        }

        [Fact]
        public void ValidateCsv_WhenCsvColumnsHasMissingColumns_ShouldReturnFalse()
        {
            // Arrange
            var byteArray = GenerateUserInputDtoAsByteArray(missingProperty: true);

            // Arrange
            var result = _csvHelper.ValidateCsv<UserInputDto>(byteArray, _expectedFields);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateCsv_WhenCsvHeadersDoNotMatchToExpectedFields_ShouldReturnFalse()
        {
            // Arrange
            var byteArray = GenerateUserInputDtoAsByteArray(wrongHeader: true);

            // Arrange
            var result = _csvHelper.ValidateCsv<UserInputDto>(byteArray, _expectedFields);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateCsv_WhenCsvColumnsOrderDoNotMatchToExpectedOrder_ShouldReturnFalse()
        {
            // Arrange
            var byteArray = GenerateUserInputDtoAsByteArray(wrongPropertiesOrder: true);

            // Arrange
            var result = _csvHelper.ValidateCsv<UserInputDto>(byteArray, _expectedFields);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateCsv_WhenSomeExpectedFieldValuesIsMissing_ShouldReturnFalse()
        {
            // Arrange
            var byteArray = GenerateUserInputDtoAsByteArray(missingValue: true);

            // Arrange
            var result = _csvHelper.ValidateCsv<UserInputDto>(byteArray, _expectedFields);

            // Assert
            Assert.False(result);
        }

        private static byte[] GenerateUserInputDtoAsByteArray(
            bool missingProperty = false,
            bool missingValue = false,
            bool wrongHeader = false,
            bool wrongPropertiesOrder = false)
        {
            UserInputDto dto;

            if (missingProperty)
            {
                dto = new UserInputDto { 
                    Gender = string.Empty 
                }.PopulateEmptyValuesWithFakeData();
            }
            else if (missingValue)
            {
                #pragma warning disable CS8625
                dto = new UserInputDto { 
                    Name = null 
                }.PopulateEmptyValuesWithFakeData();
                #pragma warning restore CS8625
            }
            else
            {
                dto = new UserInputDto().PopulateEmptyValuesWithFakeData();
            }

            try
            {
                var byteArray = Array.Empty<byte>();

                using var memoryStream = new MemoryStream();
                using var writer = new StreamWriter(memoryStream);
                {
                    var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
                    using var csv = new CsvWriter(writer, csvConfiguration);

                    if (missingProperty)
                        csv.Context.RegisterClassMap<UserCsvMapperWithoutLocationData>();
                    else if (wrongPropertiesOrder)
                        csv.Context.RegisterClassMap<UserCsvMapperWithWrongOrder>();
                    else if (wrongHeader)
                        csv.Context.RegisterClassMap<UserCsvMapperWithWrongHeader>();
                    else
                        csv.Context.RegisterClassMap<UserCsvMapper>();

                    csv.WriteRecords([dto]);

                    writer.Flush();
                    byteArray = memoryStream.ToArray();
                }

                return byteArray;
            }
            catch (TypeConverterException ex)
            {
                throw new InvalidCastException($"It's not possible to convert the text '{ex.Text}', column '{ex.MemberMapData.Member!.Name}', line '{ex.Context!.Parser!.Row}'");
            }
        }
    }
}
