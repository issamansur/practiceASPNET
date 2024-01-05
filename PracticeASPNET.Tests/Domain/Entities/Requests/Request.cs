using System;
using System.Collections.Generic;
using AutoFixture;
using Moq;
using PracticeASPNET.Domain.Entities.Requests;
using PracticeASPNET.Domain.Entities.Requests.Events;
using PracticeASPNET.Domain.Entities.Users;
using PracticeASPNET.Domain.Enums;
using Xunit;

namespace PracticeASPNET.Tests.Domain.Entities.Requests;

public class RequestTests
{
    [Fact]
    public void Create_ValidData_ShouldCreateRequestWithPendingStatus()
    {
        // Arrange
        var fixture = new Fixture();
        var userMock = fixture.Create<User>();
        var documentMock = fixture.Create<Document>();
        var workflowMock = fixture.Create<Workflow>();

        // Act
        var request = Request.Create(userMock, documentMock, workflowMock);

        // Assert
        Assert.NotNull(request);
        Assert.Equal(Status.Pending, request.Status);
        Assert.Equal(0, request.CurrentStep);
        Assert.NotEmpty(request.Events);
        Assert.Contains(request.Events, e => e is RequestCreateEvent);
    }

    [Fact]
    public void SetDocument_ValidDocument_ShouldSetDocument()
    {
        // Arrange
        var fixture = new Fixture();
        var request = fixture.Create<Request>();
        var newDocument = fixture.Create<Document>();

        // Act
        request.SetDocument(newDocument);

        // Assert
        Assert.Equal(newDocument, request.Document);
    }

    [Fact]
    public void AddEvent_ValidEvent_ShouldAddEventToList()
    {
        // Arrange
        var fixture = new Fixture();
        var request = fixture.Create<Request>();
        var eventMock = fixture.Create<Event>();

        // Act
        request.AddEvent(eventMock);

        // Assert
        Assert.Contains(eventMock, request.Events);
    }

    [Fact]
    public void Approve_ValidUserAndPendingStep_ShouldApproveAndAdvanceToNextStep()
    {
        // Arrange
        var fixture = new Fixture();
        var request = fixture.Create<Request>();
        var userMock = fixture.Create<User>();

        // Act
        request.Approve(userMock);

        // Assert
        Assert.Equal(Status.Approved, request.Status);
        Assert.Equal(1, request.CurrentStep);
        Assert.NotEmpty(request.Events);
        Assert.Contains(request.Events, e => e is RequestApproveEvent);
    }

    [Fact]
    public void Reject_ValidUserAndPendingStep_ShouldRejectAndSetOverallStatusToRejected()
    {
        // Arrange
        var fixture = new Fixture();
        var request = fixture.Create<Request>();
        var userMock = fixture.Create<User>();

        // Act
        request.Reject(userMock);

        // Assert
        Assert.Equal(Status.Rejected, request.Status);
        Assert.NotEmpty(request.Events);
        Assert.Contains(request.Events, e => e is RequestRejectEvent);
    }

    [Fact]
    public void Restart_ValidUser_ShouldRestartRequestAndSetToFirstWorkflowStep()
    {
        // Arrange
        var fixture = new Fixture();
        var request = fixture.Create<Request>();
        var userMock = fixture.Create<User>();

        // Act
        request.Restart(userMock);

        // Assert
        Assert.Equal(Status.Pending, request.Status);
        Assert.Equal(0, request.CurrentStep);
        Assert.NotEmpty(request.Events);
        Assert.Contains(request.Events, e => e is RequestRestartEvent);
    }

    [Fact]
    public void Freeze_ValidUserAndPendingStep_ShouldFreezeCurrentStep()
    {
        // Arrange
        var fixture = new Fixture();
        var request = fixture.Create<Request>();
        var userMock = fixture.Create<User>();

        // Act
        request.Freeze(userMock);

        // Assert
        Assert.Equal(Status.Frozen, request.Workflow.Steps[request.CurrentStep].Status);
        Assert.NotEmpty(request.Events);
        Assert.Contains(request.Events, e => e is RequestFreezeEvent);
    }
}
