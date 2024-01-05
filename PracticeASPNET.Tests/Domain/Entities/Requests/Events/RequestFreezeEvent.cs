﻿using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Requests.Events;
using System;

namespace PracticeASPNET.Tests.Domain.Entities.Requests.Events
{
    public class RequestFreezeEventTests
    {
        private readonly IFixture _fixture;

        public RequestFreezeEventTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var requestId = _fixture.Create<Guid>();
            var data = _fixture.Create<string>();

            // Act
            var my_event = new RequestFreezeEvent(id, requestId, data);

        // Assert
        Assert.Equal(id, my_event.Id);
        Assert.Equal(requestId, my_event.RequestId);
        Assert.Equal(data, my_event.Data);
        }

        [Fact]
        public void Create_CreatesEventWithCorrectProperties()
        {
            // Arrange
            var requestId = _fixture.Create<Guid>();
            var data = _fixture.Create<string>();

            // Act
            var my_event = RequestFreezeEvent.Create(requestId, data);

            // Assert
            Assert.Equal(requestId, my_event.RequestId);
        Assert.Equal(data, my_event.Data);
        }
    }
}