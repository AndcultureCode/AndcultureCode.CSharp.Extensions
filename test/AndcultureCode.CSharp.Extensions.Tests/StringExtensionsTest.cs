using AndcultureCode.CSharp.Extensions.Tests.Stubs;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class StringExtensionsTest
    {
        #region AsIndentedJson
        [Fact]
        public void AsIndentedJson_Null_Argument()
        {
            string text = null;
            text            // Arrange
             .AsIndentedJson()  // Act
                 .ShouldBe(null);// Assert
        }

        [Fact]
        public void AsIndentedJson_WhiteSpace_Argument()
        {
            string text = "   ";
            text            // Arrange
             .AsIndentedJson()  // Act
                 .ShouldBe(""); // Assert
        }

        [Fact]
        public void AsIndentedJson_Invalid_Argument()
        {
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => " {IValid]}}".AsIndentedJson());
        }

        [Fact]
        public void AsIndentedJson__Argument()
        {
            var testEntity = new TestEntity() {
                Name = "AndcultureCode",
                EmailAddress = "example@test.com"
            };
            
            string jsonEntity = JsonConvert.SerializeObject(testEntity, Formatting.None);
            jsonEntity.AsIndentedJson().ShouldNotBe<string>(jsonEntity);
        }
        #endregion

        #region ToBoolean
        [Fact]
        public void ToBoolean_ShouldBeTrue()
        {
            string[] arr = new string[] {"true", "t", "1" };
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]          // Arrange
                    .ToBoolean()    // Act
                    .ShouldBeTrue();// Assert
            }
        }

        [Fact]
        public void ToBoolean_ShouldBeFalse()
        {
            string[] arr = new string[] { "false", "f", "0" };
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]          // Arrange
                    .ToBoolean()     // Act
                    .ShouldBeFalse();// Assert
            }
        }

        [Fact]
        public void ToBoolean_Give_null_Argument()
        {
            string text = null;
            text            // Arrange
                .ToBoolean()     // Act
                .ShouldBeFalse();// Assert
        }

        [Fact]
        public void ToBoolean_Give_Empty_Argument()
        {
            string.Empty            // Arrange
                .ToBoolean()     // Act
                .ShouldBeFalse();// Assert
        }
        #endregion

        #region ToInt
        [Fact]
        public void ToToInt_ShouldBeFalse()
        {
            "not number"            // Arrange
                .ToBoolean()     // Act
                .ShouldBeFalse();// Assert
        }

        [Fact]
        public void ToInt_Give_null_Argument()
        {
            string text = null;
            text            // Arrange
                .ToBoolean()     // Act
                .ShouldBeFalse();// Assert
        }
        #endregion
    }
}


