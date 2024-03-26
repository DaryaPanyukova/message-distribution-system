using MessageDistributionSystem.Exceptions;
using MessageDistributionSystem.Loggers;
using MessageDistributionSystem.MessageEndpoint;
using MessageDistributionSystem.MessageEndpoint.Messengers;
using MessageDistributionSystem.Messages;
using MessageDistributionSystem.Receiver;
using MessageDistributionSystem.Topics;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class TopicTest
{
    [Fact]
    public void UnreadMessageTest()
    {
        // Arrange
        var user = new User();
        int messageId = 10;
        var message = new Message(messageId, "Title", "Body", 5);

        // Act
        user.ReceiveMessage(message);

        // Assert
        Assert.False(user.IsMessageRead(messageId));
    }

    [Fact]
    public void MarkUnreadMessageReadTest()
    {
        // Arrange
        var user = new User();
        int messageId = 7;
        var message = new Message(messageId, "Title", "Body", 5);

        // Act
        user.ReceiveMessage(message);
        user.MarkMessageRead(messageId);

        // Assert
        Assert.True(user.IsMessageRead(messageId));
    }

    [Fact]
    public void MarkReadMessageReadTest()
    {
        // Arrange
        var user = new User();
        int messageId = 7;
        var message = new Message(messageId, "Title", "Body", 5);

        // Act
        user.ReceiveMessage(message);
        user.MarkMessageRead(messageId);

        // Assert
        Assert.Throws<ReadMessageTwiceException>(() => user.MarkMessageRead(messageId));
    }

    [Fact]
    public void ImportanceLevelNotPassedTest()
    {
        // Arrange
        int messageId = 5434097;
        var message = new Message(messageId, "title", "body", 20);
        var receiver = new Mock<IReceiver>();
        var logger = new Mock<ILogger>();
        var loggerDecorator = new LoggingMessagesDecorator(logger.Object, receiver.Object);
        var proxy = new ImportanceLevelProxy(loggerDecorator, 10);

        // Act
        proxy.ReceiveMessage(message);

        // Assert
        receiver.Verify(curReceiver => curReceiver.ReceiveMessage(message), Times.Never);
    }

    [Fact]
    public void ImportanceLevelPassedTest()
    {
        // Arrange
        int messageId = 5434097;
        var message = new Message(messageId, "title", "body", 20);
        var receiver = new Mock<IReceiver>();
        var logger = new Mock<ILogger>();
        var loggerDecorator = new LoggingMessagesDecorator(logger.Object, receiver.Object);
        var proxy = new ImportanceLevelProxy(loggerDecorator, 45);

        // Act
        proxy.ReceiveMessage(message);

        // Assert
        receiver.Verify(curReceiver => curReceiver.ReceiveMessage(message), Times.Once);
    }

    [Fact]
    public void LoggingTest()
    {
        // Arrange
        int messageId = 5434097;
        var message = new Message(messageId, "title", "body", 20);

        var receiverMock = new Mock<IReceiver>();

        var loggerMock = new Mock<ILogger>();
        var loggerDecorator = new LoggingMessagesDecorator(loggerMock.Object, receiverMock.Object);

        var proxy = new ImportanceLevelProxy(loggerDecorator, 45);
        var topic = new Topic("Name", proxy);

        // Act
        topic.SendMessage(message);

        // Assert
        loggerMock.Verify(logger => logger.Log(message), Times.Once);
    }

    [Fact]
    public void MessengerTest()
    {
        // Arrange
        int messageId = 5434097;
        var message = new Message(messageId, "title", "body", 20);

        var telegramMock = new Mock<ITelegramMessenger>();
        var messengerAdapter = new TelegramMessengerAdapter(telegramMock.Object);

        // Act
        messengerAdapter.ReceiveMessage(message);

        // Assert
        telegramMock.Verify(messenger => messenger.PostNewMessage("Notification", message.AsString()), Times.Once);
    }
}