using Microsoft.VisualStudio.TestTools.UnitTesting;
using demo_project_ver_5.Class;

namespace demo_project_ver_5.Class.Tests
{
    [TestClass()]
    public class ValidationHelperTests
    {
        [TestMethod()]
        public void ValidateRegistration_AllFieldsValid_ReturnsEmptyString()
        {
            // Arrange
            string selectedRegType = "User";
            string password1 = "password123";
            string password2 = "password123";
            string login = "testuser";

            // Act
            string result = ValidationHelper.ValidateRegistration(selectedRegType, password1, password2, login);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        [TestMethod()]
        public void ValidateRegistration_SelectedRegTypeIsNull_ReturnsErrorMessage()
        {
            // Arrange
            string selectedRegType = null;
            string password1 = "password123";
            string password2 = "password123";
            string login = "testuser";

            // Act
            string result = ValidationHelper.ValidateRegistration(selectedRegType, password1, password2, login);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("Выберите тип пользователя !"));
        }

        [TestMethod()]
        public void ValidateRegistration_PasswordsDoNotMatch_ReturnsErrorMessage()
        {
            // Arrange
            string selectedRegType = "User";
            string password1 = "password123";
            string password2 = "password456";
            string login = "testuser";

            // Act
            string result = ValidationHelper.ValidateRegistration(selectedRegType, password1, password2, login);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("Пароли не совпадают !"));
        }

        [TestMethod()]
        public void ValidateRegistration_PasswordIsTooShort_ReturnsErrorMessage()
        {
            // Arrange
            string selectedRegType = "User";
            string password1 = "pass";
            string password2 = "pass";
            string login = "testuser";

            // Act
            string result = ValidationHelper.ValidateRegistration(selectedRegType, password1, password2, login);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("Пароль не может быть меньше 6 символов !"));
        }

        [TestMethod()]
        public void ValidateRegistration_LoginIsEmpty_ReturnsErrorMessage()
        {
            // Arrange
            string selectedRegType = "User";
            string password1 = "password123";
            string password2 = "password123";
            string login = "";

            // Act
            string result = ValidationHelper.ValidateRegistration(selectedRegType, password1, password2, login);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("Введите логин !"));
        }
    }
}