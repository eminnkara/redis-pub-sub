using StackExchange.Redis;

using ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
var sub = redis.GetSubscriber();

var channel = "testChannel";

do
{
    var input = Console.ReadLine();
    sub.Publish(channel, input);
} while (true);