using Moq;
using Xunit;
using System;
using Weekdays.Services;
using Weekdays.Models;

namespace WeekdaysTests
{

    public class WeekdaysControllerTest
    {
        private readonly Mock<IWeekdaysService> _mockIWeekdaysService;

        public WeekdaysControllerTest()
        {
            _mockIWeekdaysService = new Mock<IWeekdaysService>();
        }

        [Fact]
        public async void GetWeekDays_Success_Result()
        {
            // Act
            var result = new WeekdaysInfo();
            _mockIWeekdaysService.Setup(e => e.GetWeekDaysAsync(It.IsAny<DateTime>())).Returns(result);

            // Assert
            Assert.NotNull(result);

        }
    }
}
